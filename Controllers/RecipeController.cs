using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using thebarback.Data;

namespace thebarback.Controllers
{
    public class RecipeController
    {
        public RecipeData recipeDatabase;

        public RecipeController()
        {
            recipeDatabase = new RecipeData();
        }

        public IActionResult Get(int id)
        {
            var recipe = recipeDatabase.GetRecipe(id);
            return new JsonResult(recipe);
        }

        public IActionResult GetRecipes()
        {
            var recipe = recipeDatabase.GetRecipes(new List<string> { "gin", "orange" });
            return new JsonResult(recipe);
        }
    }
}
