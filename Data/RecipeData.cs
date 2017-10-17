using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using thebarback.Models;

namespace thebarback.Data
{
    public class RecipeData : IDatabase
    {
        public Recipe GetRecipe(int cocktailID)
        {
            //Create method at top of class that initializes database connection upon website load?
            //Store credentials in settings file?
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "{db server}";
            builder.UserID = "{admin ID}";
            builder.Password = "{password}";
            builder.InitialCatalog = "{db name}";

            Recipe recipe = new Recipe();
            List<CocktailIngredient> ingredients = new List<CocktailIngredient>();
            List<CocktailIngredient> garnish = new List<CocktailIngredient>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                //Query to return Cocktail based on CocktailID
                StringBuilder sbCoc = new StringBuilder();
                sbCoc.Append("SELECT CocktailName, [Description], Preparation, ServiceName, DrinkwareName ");
                sbCoc.Append("FROM Cocktails C ");
                sbCoc.Append("INNER JOIN Service S ON C.ServiceID = S.ServiceID ");
                sbCoc.Append("INNER JOIN Drinkware D ON C.DrinkwareID = D.DrinkwareID ");
                sbCoc.Append("WHERE CocktailID = ");
                sbCoc.Append(cocktailID);

                string sqlCoc = sbCoc.ToString();

                using (SqlCommand command = new SqlCommand(sqlCoc, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int name = reader.GetOrdinal("CocktailName");
                        int desc = reader.GetOrdinal("Description");
                        int prep = reader.GetOrdinal("Preparation");
                        int serv = reader.GetOrdinal("ServiceName");
                        int drink = reader.GetOrdinal("DrinkwareName");

                        //Assign values returned from SQL query to Recipe object
                        while (reader.Read())
                        {
                            recipe.Name = reader.GetString(name);
                            recipe.Description = reader.GetString(desc);
                            recipe.Preparation = reader.GetString(prep);
                            recipe.Service = reader.GetString(serv);
                            recipe.Drinkware = reader.GetString(drink);
                        }
                    }
                }

                StringBuilder sbIng = new StringBuilder();
                sbIng.Append("SELECT Amount, MeasurementAbbrev, IngredientName ");
                sbIng.Append("FROM CocktailIngredient CI ");
                sbIng.Append("INNER JOIN Ingredients I ON CI.IngredientID = I.IngredientID ");
                sbIng.Append("INNER JOIN Cocktails C ON CI.CocktailID = C.CocktailID ");
                sbIng.Append("INNER JOIN Measurements M ON CI.MeasurementID = M.MeasurementID ");
                sbIng.Append("WHERE C.CocktailID = ");
                sbIng.Append(cocktailID);

                string sqlIng = sbIng.ToString();

                using (SqlCommand command = new SqlCommand(sqlIng, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int amount = reader.GetOrdinal("Amount");
                        int measurement = reader.GetOrdinal("MeasurementAbbrev");
                        int ingredientName = reader.GetOrdinal("IngredientName");

                        //Assign values from ingredient query to new Cocktail Ingredient objects
                        //Add the new Ingredient object to a list
                        while (reader.Read())
                        {
                            var ingredient = new CocktailIngredient();
                            ingredient.Amount = reader.GetDouble(amount);
                            ingredient.Measurement = reader.GetString(measurement);
                            ingredient.IngredientName = reader.GetString(ingredientName);
                            ingredients.Add(ingredient);
                        }
                    }
                }

                StringBuilder sbGarn = new StringBuilder();
                sbGarn.Append("SELECT GarnishName FROM CocktailGarnish CG ");
                sbGarn.Append("INNER JOIN Garnish G ON CG.GarnishID = G.GarnishID ");
                sbGarn.Append("WHERE CG.CocktailID = ");
                sbGarn.Append(cocktailID);

                string sqlGarn = sbGarn.ToString();

                using (SqlCommand command = new SqlCommand(sqlGarn, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int gar = reader.GetOrdinal("GarnishName");

                        //Assign values from garnish query to Cocktail Ingredient objects
                        //Add new ingredient objects to separate garnish list
                        while (reader.Read())
                        {
                            var ingredient = new CocktailIngredient();
                            ingredient.IngredientName = reader.GetString(gar);
                            garnish.Add(ingredient);
                        }
                    }
                }
            }

                //string connectionString = null;
                //SqlConnection connection;


                //string ingSql = null;
                //string garnSql = null;
                //string cocSql = null;

                //connectionString = @"data source=.\sqlexpress;initial catalog=Barback;integrated security=true;";

                //ingSql = String.Format("SELECT Amount, MeasurementAbbrev, IngredientName FROM CocktailIngredient CI INNER JOIN Ingredients I ON CI.IngredientID = I.IngredientID INNER JOIN Cocktails C ON CI.CocktailID = C.CocktailID INNER JOIN Measurements M ON CI.MeasurementID = M.MeasurementID WHERE C.CocktailID = {0}", cocktailID);
                //garnSql = String.Format("SELECT GarnishName FROM CocktailGarnish CG INNER JOIN Garnish G ON CG.GarnishID = G.GarnishID WHERE CG.CocktailID = {0}", cocktailID);
                //cocSql = String.Format("SELECT CocktailName,[Description],Preparation,ServiceName,DrinkwareName FROM Cocktails C INNER JOIN Service S ON C.ServiceID = S.ServiceID INNER JOIN Drinkware D ON C.DrinkwareID = D.DrinkwareID WHERE CocktailID = {0}", cocktailID);

                //using (connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    using (var cmd = new SqlCommand(cocSql, connection))
                //    {
                //        using (SqlDataReader reader = cmd.ExecuteReader())
                //        {
                //            int name = reader.GetOrdinal("CocktailName");
                //            int desc = reader.GetOrdinal("Description");
                //            int prep = reader.GetOrdinal("Preparation");
                //            int serv = reader.GetOrdinal("ServiceName");
                //            int drink = reader.GetOrdinal("DrinkwareName");
                //            while (reader.Read())
                //            {
                //                recipe.Name = reader.GetString(name);
                //                recipe.Description = reader.GetString(desc);
                //                recipe.Preparation = reader.GetString(prep);
                //                recipe.Service = reader.GetString(serv);
                //                recipe.Drinkware = reader.GetString(drink);
                //            }
                //        }
                //    }

                //    using (var cmd = new SqlCommand(ingSql, connection))
                //    {
                //        using (SqlDataReader reader = cmd.ExecuteReader())
                //        {
                //            int amount = reader.GetOrdinal("Amount");
                //            int measurement = reader.GetOrdinal("MeasurementAbbrev");
                //            int ingredientName = reader.GetOrdinal("IngredientName");
                //            while(reader.Read())
                //            {
                //                var ingredient = new CocktailIngredient();
                //                ingredient.Amount = reader.GetDouble(amount);
                //                ingredient.Measurement = reader.GetString(measurement);
                //                ingredient.IngredientName = reader.GetString(ingredientName);
                //                ingredients.Add(ingredient);
                //            }
                //        }
                //    }

                //    using (var cmd = new SqlCommand(garnSql, connection))
                //    {
                //        using (SqlDataReader reader = cmd.ExecuteReader())
                //        {
                //            int gar = reader.GetOrdinal("GarnishName");
                //            while(reader.Read())
                //            {
                //                var ingredient = new CocktailIngredient();
                //                ingredient.IngredientName = reader.GetString(gar);
                //                garnish.Add(ingredient);
                //            }
                //        }
                //    }
                //}

            recipe.Garnishes = garnish;
            recipe.Ingredients = ingredients;

            return recipe;
        }

        public List<Recipe> GetRecipes(string keyword)
        {
            List<Recipe> recipes = new List<Recipe>();
            string connectionString = null;
            SqlConnection connection;
            string sql = null;

            connectionString = @"data source=.\sqlexpress;initial catalog=Barback;integrated security=true;";

            sql = String.Format("SELECT CocktailID FROM CocktailTag C INNER JOIN Tags T ON C.TagID = T.TagID WHERE TagName LIKE '%{0}%'", keyword);

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int id = reader.GetOrdinal("CocktailID");
                        while (reader.Read())
                        {
                            Recipe recipe = GetRecipe(reader.GetInt32(id));
                            recipes.Add(recipe);
                        }
                    }
                }
            }
            return recipes;
        }

        public List<Recipe> GetRecipes(List<string> keywords)
        {
            throw new NotImplementedException();
        }
    }
}
