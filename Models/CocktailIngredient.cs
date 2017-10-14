using System;

namespace thebarback.Models
{
    public class CocktailIngredient
    {
        public int ID { get; set; }
        public int CocktailID { get; set; }
        public string IngredientName { get; set; }
        public Object Amount { get; set; }
        public string Measurement { get; set; }
    }
}