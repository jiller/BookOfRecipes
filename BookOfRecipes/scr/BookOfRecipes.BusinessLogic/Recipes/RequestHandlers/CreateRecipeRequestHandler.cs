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
        private readonly IMapper _mapper;

        public CreateRecipeRequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected override async Task Handle(CreateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipeToCreate = _mapper.Map<Recipe>(request.Recipe);
            var recipeVariation = _mapper.Map<RecipeVariation>(request.Recipe);

            using (var db = new BookOfRecipesContext())
            {
                var existedRecipe = await db.Recipes
                    .Include(r => r.Variations)
                    .FirstOrDefaultAsync(r => r.Name.Equals(recipeToCreate.Name))
                    .ConfigureAwait(false);

                if (existedRecipe == null)
                {
                    db.Recipes.Add(new Recipe
                    {
                        Name = recipeToCreate.Name,
                        Variations = new List<RecipeVariation>
                        {
                            recipeVariation
                        }
                    });
                }
                else
                {
                    existedRecipe.Variations.Add(recipeVariation);
                }

                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}