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
        //public MockRecipeData recipeDatabase;
        public RecipeData recipeDatabase;

        public RecipeController()
        {
            //recipeDatabase = new MockRecipeData();
            recipeDatabase = new RecipeData();
        }

        public IActionResult Get(int id)
        {
            var recipe = recipeDatabase.GetRecipe(id);
            return new JsonResult(recipe);
        }
    }
}
