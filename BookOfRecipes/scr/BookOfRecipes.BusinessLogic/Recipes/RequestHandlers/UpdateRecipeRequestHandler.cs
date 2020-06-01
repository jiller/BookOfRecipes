using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BookOfRecipes.BusinessLogic.Recipes.Requests;
using BookOfRecipes.Data;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookOfRecipes.BusinessLogic.Recipes.RequestHandlers
{
    [UsedImplicitly]
    public class UpdateRecipeRequestHandler : AsyncRequestHandler<UpdateRecipeRequest>
    {
        private readonly BookOfRecipesContext _context;
        private readonly IMapper _mapper;

        public UpdateRecipeRequestHandler(BookOfRecipesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task Handle(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipeToUpdate = request.Recipe.Name;
            var recipeVariation = _mapper.Map<RecipeVariation>(request.Recipe);

            var existedRecipe = await _context.Recipes
                .Include(r => r.Variations)
                .FirstOrDefaultAsync(r => r.Name.Equals(recipeToUpdate))
                .ConfigureAwait(false);

            if (existedRecipe == null)
            {
                throw new InvalidOperationException($"Recipe \"{recipeToUpdate}\" doesn't exist.");
            }

            var existedVariation = existedRecipe.Variations
                .FirstOrDefault(rv => rv.CreatedBy == recipeVariation.CreatedBy);

            if (existedVariation == null)
            {
                throw new InvalidOperationException($"There is not recipe \"{recipeToUpdate}\" by current user. Please use Create method");
            }

            // TODO: update properties and merge ingredients

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}