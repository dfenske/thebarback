using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thebarback.Models;

namespace thebarback.Data
{
    public class MockRecipeData : IDatabase
    {
        public Recipe GetRecipe(int cocktailID)
        {
            var recipe = new Recipe()
            {
                Description = "A cool, refreshing choice.",
                Drinkware = "Coupe",
                Garnishes = new List<CocktailIngredient>()
                {
                    new CocktailIngredient()
                    {
                        Amount = 1,
                        CocktailID = 1,
                        ID = 1,
                        IngredientName = "Cherry",
                        Measurement = ""
                    }
                },
                Ingredients = new List<CocktailIngredient>() {
                    new CocktailIngredient()
                    {
                        Amount = 1.5,
                        CocktailID = 1,
                        ID = 1,
                        IngredientName = "Gin",
                        Measurement = "oz"
                    },
                    new CocktailIngredient()
                    {
                        Amount = 1,
                        CocktailID = 1,
                        ID = 1,
                        IngredientName = "Sweet Vermouth",
                        Measurement = "oz"
                    },
                    new CocktailIngredient()
                    {
                        Amount = 1,
                        CocktailID = 1,
                        ID = 1,
                        IngredientName = "Campari",
                        Measurement = "oz"
                    }, 
                }, 
                Name = "Negroni", 
                Preparation = "Mix all ingredients in a cocktail shaker with ice. Stir, then strain into glass.",
                Tags = new List<Tag>() { new Tag() { ID = 1, Name = "Refreshing"}, new Tag() { ID = 2, Name = "Gin"} }
            };
            return recipe;
        }

        public List<Recipe> GetRecipes(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetRecipes(List<string> keywords)
        {
            throw new NotImplementedException();
        }
    }
}
