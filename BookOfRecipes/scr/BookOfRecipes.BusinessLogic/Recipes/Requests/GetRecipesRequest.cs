using System.Collections.Generic;
using BookOfRecipes.BusinessLogic.Recipes.Model;
using MediatR;

namespace BookOfRecipes.BusinessLogic.Recipes.Requests
{
    public class GetRecipesRequest : IRequest<IEnumerable<RecipeDto>>
    {
        // TODO: Add some filters
    }
}