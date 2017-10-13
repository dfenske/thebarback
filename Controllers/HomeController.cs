using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using thebarback.Data;

namespace thebarback.Controllers
{
    public class HomeController : Controller
    {
        public MockRecipeData recipeDatabase;

        public HomeController()
        {
            recipeDatabase = new MockRecipeData();
        }

        public IActionResult Index()
        {
            var recipe = recipeDatabase.GetRecipe(1);
            return View(recipe);
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
