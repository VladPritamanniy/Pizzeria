using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.DTO;
using Pizzeria.Application.Interfaces;
using Pizzeria.Core.Exceptions;

namespace Pizzeria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPizzas()
        {
            return Ok(await _menuService.GetAllPizzas());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePizza([FromForm] PizzaCreateDto dto)
        {
            try
            {
                await _menuService.CreatePizza(dto);
                return Ok();
            }
            catch (PizzaNotCreatedException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
