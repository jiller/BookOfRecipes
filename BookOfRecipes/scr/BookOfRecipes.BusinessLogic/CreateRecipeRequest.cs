using System.Threading;
using System.Threading.Tasks;
using BookOfRecipes.DataAccess.Recipes.Model;
using MediatR;

namespace BookOfRecipes.BusinessLogic
{
    public class CreateRecipeRequest : IRequest
    {
        public RecipeDto Recipe { get; set; }
    }

    public class CreateRecipeRequestHandler : AsyncRequestHandler<CreateRecipeRequest>
    {
        protected override async Task Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}