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
                            Amount = 1M,
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
                            Amount = 2M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Bourbon",
                            Measurement = "oz"
                        },
                        new CocktailIngredient()
                        {
                            Amount = 0M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Angostura Bitters",
                            Measurement = "A few drops"
                        },
                        new CocktailIngredient()
                        {
                            Amount = 0M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Water",
                            Measurement = "A splash"
                        },
                        new CocktailIngredient()
                        {
                            Amount = 1M,
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
                            Amount = 1M,
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
                            Amount = 1.5M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Gin",
                            Measurement = "oz"
                        },
                        new CocktailIngredient()
                        {
                            Amount = 1M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Sweet Vermouth",
                            Measurement = "oz"
                        },
                        new CocktailIngredient()
                        {
                            Amount = 1M,
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
                new Recipe
                {
                    Description = "Over a strong gin base, the Cynar lends a delcious bitter, vegetal flavour, with the dry vermouth lending some floral notes and also helping to emphasise the sweet characteristics of the amaro. The way the three ingredients work together is really delicious, and the resulting cocktail is at once reminiscent of the Negroni, yet distinct in its own right.",
                    Drinkware = "Rocks",
                    Garnishes = new List<CocktailIngredient>()
                    {
                        new CocktailIngredient()
                        {
                            Amount = 0M,
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
                            Amount = 1M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Tanqueray dry gin",
                            Measurement = "oz"
                        },
                        new CocktailIngredient()
                        {
                            Amount = .66M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Cynar",
                            Measurement = "oz"
                        },
                        new CocktailIngredient()
                        {
                            Amount = .5M,
                            CocktailID = 1,
                            ID = 1,
                            IngredientName = "Noilly Prat dry vermouth",
                            Measurement = "oz"
                        }
                    },
                    Name = "Berlioni",
                    Preparation = "Stir over ice then strain in to an ice filled old-fashioned glass. Garnish with a large twist of orange zest.",
                    Tags = new List<Tag>() {new Tag() {ID = 1, Name = "Refreshing"}, new Tag() {ID = 2, Name = "Gin"}},
                    ImageUrl = "https://thebarback.blob.core.windows.net/images/berlioni.jpg",
                    PhotoCred = "Gonçalo De Sousa Monteiro, Berlin bartender and Traveling Mixologist"
                }
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
