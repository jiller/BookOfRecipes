using System.Collections.Generic;

namespace BookOfRecipes.BusinessLogic.Recipes.Model
{
    public class RecipeDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string CookingDescription { get; set; }
        public int TimeOfCooking { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}