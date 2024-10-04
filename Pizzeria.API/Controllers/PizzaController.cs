using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPizzaForChangingDisplayOrder()
        {
            return Ok(await _pizzaService.GetPizzaForChangingDisplayOrder());
        }

        [HttpPost]
        public async Task<IActionResult> ChangePizzaDisplayOrdering(List<PizzaDisplayOrderingDto> dto)
        {
            await _pizzaService.ChangePizzaDisplayOrdering(dto);
            return Ok();
        }
    }
}
