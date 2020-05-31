namespace BookOfRecipes.WebApi.Recipes.Model
{
    public class IngredientDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string MeasureUnit { get; set; }
    }
}