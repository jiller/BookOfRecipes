using System.Threading;
using System.Threading.Tasks;
using BookOfRecipes.BusinessLogic.Recipes.Requests;
using JetBrains.Annotations;
using MediatR;

namespace BookOfRecipes.BusinessLogic.Recipes.RequestHandlers
{
    [UsedImplicitly]
    public class UpdateRecipeRequestHandler : AsyncRequestHandler<UpdateRecipeRequest>
    {
        protected override Task Handle(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}