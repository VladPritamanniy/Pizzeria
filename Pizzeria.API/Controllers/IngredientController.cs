using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : Controller
    {
        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientController(ILogger<IngredientController> logger, IIngredientService ingredientService)
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllIngredients()
        {
            return Ok(await _ingredientService.GetAllIngredients());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateIngredient([FromForm] IngredientDto dto)
        {
            try
            {
                await _ingredientService.CreateIngredient(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
