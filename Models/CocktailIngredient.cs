﻿namespace thebarback.Models
{
    public class CocktailIngredient
    {
        public int ID { get; set; }
        public int CocktailID { get; set; }
        public string IngredientName { get; set; }
        public double Amount { get; set; }
        public string Measurement { get; set; }
    }
}