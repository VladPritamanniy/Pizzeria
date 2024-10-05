using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Exceptions;

namespace Pizzeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(IPizzaService pizzaService, ILogger<PizzaController> logger)
        {
            _pizzaService = pizzaService;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPizzaForChangingDisplayOrder()
        {
            return Ok(await _pizzaService.GetPizzaForChangingDisplayOrder());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePizza([FromForm] PizzaCreateDto dto)
        {
            try
            {
                await _pizzaService.CreatePizza(dto);
                return Ok();
            }
            catch (PizzaNotCreatedException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ChangePizzaDisplayOrdering(List<PizzaDisplayOrderingDto> dto)
        {
            await _pizzaService.ChangePizzaDisplayOrdering(dto);
            return Ok();
        }
    }
}
