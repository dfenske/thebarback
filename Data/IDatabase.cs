using System;
using System.Collections.Generic;
using thebarback.Models;

namespace thebarback.Data
{
    interface IDatabase
    {
        Recipe GetRecipe(int cocktailID);

        List<Recipe> GetRecipes(string keyword);

        List<Recipe> GetRecipes(List<string> keywords);
    }
}
