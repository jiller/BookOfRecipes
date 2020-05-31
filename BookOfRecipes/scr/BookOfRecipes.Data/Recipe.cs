using System.Collections.Generic;

namespace BookOfRecipes.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeVariation> Variations { get; set; }
    }
}