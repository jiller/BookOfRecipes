namespace BookOfRecipes.Data
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string MeasureUnit { get; set; }
        public int RecipeId { get; set; }
        public virtual RecipeVariation Recipe { get; set; }
    }
}