using System;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using TheBarback.Configuration;

namespace TheBarback
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            Configuration = BuildConfiguration(environment);

            Environment = environment;
        }
        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; set; }

        public IHostingEnvironment Environment { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();

            var builder = new ContainerBuilder();

            builder.Populate(services);

            ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(
            IApplicationBuilder app,
            ILoggerFactory loggerFactory,
            IHostingEnvironment environment,
            IOptions<ApplicationConfiguration> options,
            IApplicationLifetime appLifetime)
        {
            ConfigureMvc(app, options);

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }

        private static IConfigurationRoot BuildConfiguration(IHostingEnvironment environment)
        {
            var builder =
                new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            return builder.Build();
        }

        private static void ConfigureMvc(IApplicationBuilder app, IOptions<ApplicationConfiguration> options)
        {
            app.UseStaticFiles();

            app.UseCors(
                builder =>
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("Retry-After"));

            app.UseMvc(
                routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

                    // Catches faulty API calls
                    routes.MapRoute(
                        "CatchInvalidAPICalls",
                        "api/{noncontroller}/{*invalid}",
                        new { controller = "Home", action = "PageNotFound", noncontroller = "!(Action|Log|Search|Survey)" });

                    routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
                });
        }
    }
}