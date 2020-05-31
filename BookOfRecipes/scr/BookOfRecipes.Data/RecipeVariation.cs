using System;

namespace BookOfRecipes.Data
{
    public class RecipeVariation: Recipe
    {
        public string Country { get; set; }
        public int Year { get; set; }
        public string CookingDescription { get; set; }
        public int TimeOfCooking { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}