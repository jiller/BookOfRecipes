using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOfRecipes.WebApi.Recipes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookOfRecipes.WebApi.Recipes
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(ILogger<RecipesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rnd = new Random();
            var recipes = Enumerable.Range(1, 5).Select(index => new RecipeDto
            {
                Year = rnd.Next(2020),
                Country = "Imaginarium",
                TimeOfCooking = rnd.Next(180)
            })
            .ToArray();

            return Ok(recipes);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Accepted();
        }

        [HttpPut]
        public IActionResult Post()
        {
            return Accepted();
        }
    }
}
