using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BookOfRecipes.BusinessLogic.Recipes.Model;
using BookOfRecipes.BusinessLogic.Recipes.Requests;
using BookOfRecipes.Data;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookOfRecipes.BusinessLogic.Recipes.RequestHandlers
{
    [UsedImplicitly]
    public class GetRecipesRequestHandler : IRequestHandler<GetRecipesRequest, IEnumerable<RecipeDto>>
    {
        private readonly BookOfRecipesContext _context;
        private readonly IMapper _mapper;

        public GetRecipesRequestHandler(BookOfRecipesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeDto>> Handle(GetRecipesRequest request, CancellationToken cancellationToken)
        {
            var recipes = await _context.RecipeVariations
                .Include(rv => rv.Author)
                .Include(rv => rv.Ingredients)
                .Include(rv => rv.Recipe)
                .OrderByDescending(rv => rv.CreatedAt)
                .Take(100)
                .ToArrayAsync()
                .ConfigureAwait(false);

            return _mapper.Map<IEnumerable<RecipeDto>>(recipes);
        }
    }
}