using System.Collections.Generic;
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
    public class CreateRecipeRequestHandler : AsyncRequestHandler<CreateRecipeRequest>
    {
        private readonly BookOfRecipesContext _context;
        private readonly IMapper _mapper;

        public CreateRecipeRequestHandler(BookOfRecipesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipeToCreate = _mapper.Map<Recipe>(request.Recipe);
            var recipeVariation = _mapper.Map<RecipeVariation>(request.Recipe);

            var existedRecipe = await _context.Recipes
                .Include(r => r.Variations)
                .FirstOrDefaultAsync(r => r.Name.Equals(recipeToCreate.Name))
                .ConfigureAwait(false);

            if (existedRecipe == null)
            {
                foreach (var ingredient in recipeVariation.Ingredients)
                {
                    ingredient.RecipeVariation = recipeVariation;
                }

                var recipe = new Recipe
                {
                    Name = recipeToCreate.Name,
                    Variations = new List<RecipeVariation>
                    {
                        recipeVariation
                    }
                };

                recipeVariation.Recipe = recipe;

                _context.Recipes.Add(recipe);
            }
            else
            {
                // TODO: Throw error if such recipe variation already exists

                recipeVariation.RecipeId = existedRecipe.Id;
                existedRecipe.Variations.Add(recipeVariation);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}