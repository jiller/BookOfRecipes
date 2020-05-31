using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookOfRecipes.DataAccess.Recipes.Model;
using MediatR;

namespace BookOfRecipes.BusinessLogic
{
    public class GetRecipesRequest : IRequest<IEnumerable<RecipeDto>>
    {
        
    }

    public class GetRecipesRequestHandler : IRequestHandler<GetRecipesRequest, IEnumerable<RecipeDto>>
    {
        public async Task<IEnumerable<RecipeDto>> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var rnd = new Random();
            return Enumerable.Range(1, 5).Select(index => new RecipeDto
                {
                    Year = rnd.Next(2020),
                    Country = "Imaginarium",
                    TimeOfCooking = rnd.Next(180)
                })
                .ToArray();
        }
    }
}