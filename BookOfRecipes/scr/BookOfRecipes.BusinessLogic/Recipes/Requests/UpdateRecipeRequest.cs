using BookOfRecipes.BusinessLogic.Recipes.Model;
using MediatR;

namespace BookOfRecipes.BusinessLogic.Recipes.Requests
{
    public class UpdateRecipeRequest : IRequest
    {
        public RecipeDto Recipe { get; set; }
    }
}