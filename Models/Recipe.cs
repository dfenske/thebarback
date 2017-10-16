using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thebarback.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Preparation { get; set; }
        public string Drinkware { get; set; }
        public string Service { get; set; }
        public List<CocktailIngredient> Ingredients { get; set; }
        public List<CocktailIngredient> Garnishes { get; set; }
        public List<Tag> Tags { get; set; }
        public string ImageUrl { get; internal set; }
        public string PhotoCred { get; internal set; }
    }
}
