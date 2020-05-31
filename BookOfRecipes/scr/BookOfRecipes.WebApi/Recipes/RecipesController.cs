using System.Threading.Tasks;
using BookOfRecipes.BusinessLogic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public async Task<IActionResult> Get()
        {
            var recipes = await _mediator.Send(new GetRecipesRequest());
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            await _mediator.Send(new CreateRecipeRequest());
            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Post()
        {
            await _mediator.Send(new UpdateRecipeRequest());
            return Accepted();
        }
    }
}
