using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
