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
            builder.DataSource = "thebarbackserver.database.windows.net";
            builder.UserID = "thebarback";
            builder.Password = "Negroni1";
            builder.InitialCatalog = "thebarbackdb";
            builder.MultipleActiveResultSets = true;

            Recipe recipe = new Recipe();
            List<CocktailIngredient> ingredients = new List<CocktailIngredient>();
            List<CocktailIngredient> garnish = new List<CocktailIngredient>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                //Query to return Cocktail based on CocktailID
                StringBuilder sbCoc = new StringBuilder();
                sbCoc.Append("SELECT CocktailName, [Description], Preparation, StyleName, DrinkwareName ");
                sbCoc.Append("FROM Cocktails C ");
                sbCoc.Append("INNER JOIN Style S ON C.StyleID = S.StyleID ");
                sbCoc.Append("INNER JOIN Drinkware D ON C.DrinkwareID = D.DrinkwareID ");
                sbCoc.Append("WHERE CocktailID = ");
                sbCoc.Append(cocktailID);
                sbCoc.Append(";");

                string sqlCoc = sbCoc.ToString();

                using (SqlCommand cmdCocktail = new SqlCommand(sqlCoc, connection))
                {
                    using (SqlDataReader reader = cmdCocktail.ExecuteReader())
                    {
                        int name = reader.GetOrdinal("CocktailName");
                        int desc = reader.GetOrdinal("Description");
                        int prep = reader.GetOrdinal("Preparation");
                        int style = reader.GetOrdinal("StyleName");
                        int drink = reader.GetOrdinal("DrinkwareName");

                        //Assign values returned from SQL query to Recipe object
                        while (reader.Read())
                        {
                            recipe.Name = reader.GetString(name);
                            recipe.Description = reader.GetString(desc);
                            recipe.Preparation = reader.GetString(prep);
                            recipe.Style = reader.GetString(style);
                            recipe.Drinkware = reader.GetString(drink);
                        }
                    }
                }

                StringBuilder sbIng = new StringBuilder();
                sbIng.Append("SELECT Amount, COALESCE(MeasurementAbbrev, MeasurementName) AS Measurement, IngredientName ");
                sbIng.Append("FROM CocktailIngredient CI ");
                sbIng.Append("INNER JOIN Ingredients I ON CI.IngredientID = I.IngredientID ");
                sbIng.Append("INNER JOIN Cocktails C ON CI.CocktailID = C.CocktailID ");
                sbIng.Append("INNER JOIN Measurements M ON CI.MeasurementID = M.MeasurementID ");
                sbIng.Append("WHERE C.CocktailID = ");
                sbIng.Append(cocktailID);
                sbIng.Append(";");

                string sqlIng = sbIng.ToString();

                using (SqlCommand cmdIngredients = new SqlCommand(sqlIng, connection))
                {
                    using (SqlDataReader reader = cmdIngredients.ExecuteReader())
                    {
                        int amount = reader.GetOrdinal("Amount");
                        int measurement = reader.GetOrdinal("Measurement");
                        int ingredientName = reader.GetOrdinal("IngredientName");

                        //Assign values from ingredient query to new Cocktail Ingredient objects
                        //Add the new Ingredient object to a list
                        while (reader.Read())
                        {
                            var ingredient = new CocktailIngredient();
                            ingredient.Amount = reader.GetDecimal(amount);
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
                sbGarn.Append(";");

                string sqlGarn = sbGarn.ToString();

                using (SqlCommand cmdGarnish = new SqlCommand(sqlGarn, connection))
                {
                    using (SqlDataReader reader = cmdGarnish.ExecuteReader())
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

                StringBuilder sbPhoto = new StringBuilder();
                sbPhoto.Append("SELECT PhotoURL, PhotoCredit FROM Photo P ");
                sbPhoto.Append("INNER JOIN CocktailPhoto CP ON P.PhotoID = CP.PhotoID ");
                sbPhoto.Append("INNER JOIN Cocktails C ON C.CocktailID = CP.CocktailID ");
                sbPhoto.Append("WHERE C.CocktailID = ");
                sbPhoto.Append(cocktailID);
                sbPhoto.Append(";");

                string sqlPhoto = sbPhoto.ToString();

                using (SqlCommand cmdPhoto = new SqlCommand(sqlPhoto, connection))
                {
                    using (SqlDataReader reader = cmdPhoto.ExecuteReader())
                    {
                        int photoURL = reader.GetOrdinal("PhotoURL");
                        int photoCred = reader.GetOrdinal("PhotoCredit");

                        //Assign values from garnish query to Cocktail Ingredient objects
                        //Add new ingredient objects to separate garnish list
                        while (reader.Read())
                        {
                            recipe.ImageUrl = reader.GetString(photoURL);
                            if (!reader.IsDBNull(photoCred))
                            {
                                recipe.PhotoCred = reader.GetString(photoCred);
                            }
                        }
                    }
                }
            }

            recipe.Garnishes = garnish;
            recipe.Ingredients = ingredients;

            return recipe;
        }

        public List<Recipe> GetRecipes(string keyword)
        {
            List<Recipe> recipes = new List<Recipe>();
            List<int> cocktailIDs = new List<int>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "thebarbackserver.database.windows.net";
            builder.UserID = "thebarback";
            builder.Password = "Negroni1";
            builder.InitialCatalog = "thebarbackdb";
            builder.MultipleActiveResultSets = true;

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT c.CocktailID ");
                sb.Append("FROM Cocktails c ");
                sb.Append("LEFT JOIN CocktailIngredient ci ON c.CocktailID = ci.CocktailID ");
                sb.Append("LEFT JOIN Ingredients i ON i.IngredientID = ci.IngredientID ");
                sb.Append("LEFT JOIN CocktailTag ct ON c.CocktailID = ct.CocktailID ");
                sb.Append("LEFT JOIN Tags t ON ct.TagID = t.TagID ");
                sb.Append("LEFT JOIN CocktailGarnish cg ON c.CocktailID = cg.CocktailID ");
                sb.Append("LEFT JOIN Garnish g ON cg.GarnishID = g.GarnishID ");
                sb.Append("LEFT JOIN Drinkware d ON c.DrinkwareID = d.DrinkwareID ");
                sb.Append("LEFT JOIN Style s ON s.StyleID = c.StyleID ");
                sb.Append("WHERE StyleName LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("OR CocktailName LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("OR [Description] LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("OR Preparation LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("OR GarnishName LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("OR TagName LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("OR IngredientName LIKE '%");
                sb.Append(keyword);
                sb.Append("%' ");
                sb.Append("GROUP BY c.CocktailID;");

                string sql = sb.ToString();

                using (SqlCommand cmdCocktailList = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = cmdCocktailList.ExecuteReader())
                    {
                        int cocktailID = reader.GetOrdinal("CocktailID");

                        //Assign values from garnish query to Cocktail Ingredient objects
                        //Add new ingredient objects to separate garnish list
                        while (reader.Read())
                        {
                            cocktailIDs.Add(reader.GetInt32(cocktailID));
                        }
                    }
                }
            }

            foreach(int ID in cocktailIDs)
            {
                Recipe recipe = GetRecipe(ID);
                recipes.Add(recipe);
            }

            return recipes;
        }

        public List<Recipe> GetRecipes(List<string> keywords)
        {
            //Return a list of CocktailIDs?
            //Then use GetRecipe for each individual lookup?
            throw new NotImplementedException();
        }
    }
}
