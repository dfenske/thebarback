using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thebarback.Models;

namespace thebarback.Data
{
    public class MockRecipeData : IDatabase
    {
        private Recipe[] recipes = 
            {
                new Recipe
                {
                    Description = "A spirit forward cocktail.",
                    Drinkware = "Rocks",
                    Garnishes = new List<CocktailIngredient>()
                    {
                        new CocktailIngredient()
                        {
                            Amount = 1,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Orange Twist",
                            Measurement = ""
                        }
                    },
                    Ingredients = new List<CocktailIngredient>()
                    {
                        new CocktailIngredient()
                        {
                            Amount = 2,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Bourbon",
                            Measurement = "oz"
                        },
                        new CocktailIngredient()
                        {
                            Amount = "A few drops",
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Angostura Bitters",
                            Measurement = ""
                        },
                        new CocktailIngredient()
                        {
                            Amount = "A splash",
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Water",
                            Measurement = ""
                        },
                        new CocktailIngredient()
                        {
                            Amount = "1",
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Sugar Cube",
                            Measurement = ""
                        }
                    },
                    Name = "Old Fashioned",
                    Preparation =
                        "Muddle sugar with water, add bitters. Then stir bourbon in with ice and strain over ice into glass.",
                    Tags = new List<Tag>()
                    {
                        new Tag() {ID = 1, Name = "Spirit-forward"},
                        new Tag() {ID = 2, Name = "Winter"},
                        new Tag() {ID = 3, Name = "Bourbon"}
                    },
                    ImageUrl = "https://thebarback.blob.core.windows.net/images/kaufmann-mercantile.jpg"
                },
                new Recipe
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
                    Ingredients = new List<CocktailIngredient>()
                    {
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
                    Tags = new List<Tag>() {new Tag() {ID = 1, Name = "Refreshing"}, new Tag() {ID = 2, Name = "Gin"}},
                    ImageUrl = "https://thebarback.blob.core.windows.net/images/david-straight.jpg"
                },
            };

        public Recipe GetRecipe(int id)
        {
            return recipes[id];
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
