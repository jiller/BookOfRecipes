using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookOfRecipes.BusinessLogic;
using BookOfRecipes.BusinessLogic.Recipes.Model;
using BookOfRecipes.BusinessLogic.Recipes.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace BookOfRecipes.WebApi.Recipes
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IMediator _mediator;

        public RecipesController(ILogger<RecipesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.OK, "List of recipes", typeof(IEnumerable<RecipeDto>))]
        public async Task<IActionResult> Get()
        {
            var recipes = await _mediator.Send(new GetRecipesRequest()).ConfigureAwait(false);

            return Ok(recipes);
        }

        [HttpPost]
        [SwaggerResponse((int) HttpStatusCode.Accepted, "Create a new recipe")]
        public async Task<IActionResult> Create(RecipeDto recipe)
        {
            await _mediator.Send(new CreateRecipeRequest
            {
                Recipe = recipe
            }).ConfigureAwait(false);

            return Accepted();
        }

        [HttpPut]
        [SwaggerResponse((int) HttpStatusCode.Accepted, "Update an existed recipe")]
        public async Task<IActionResult> Post(RecipeDto recipe)
        {
            await _mediator.Send(new UpdateRecipeRequest
            {
                Recipe = recipe
            }).ConfigureAwait(false);

            return Accepted();
        }
    }
}
