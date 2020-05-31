using System.Threading;
using System.Threading.Tasks;
using BookOfRecipes.DataAccess.Recipes.Model;
using MediatR;

namespace BookOfRecipes.BusinessLogic
{
    public class UpdateRecipeRequest : IRequest
    {
        public RecipeDto Recipe { get; set; }
    }

    public class UpdateRecipeRequestHandler : AsyncRequestHandler<UpdateRecipeRequest>
    {
        protected override Task Handle(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}