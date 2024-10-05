using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Route("[action]")]
        public async Task<IActionResult> GetAllPizzas()
        {
            var ty = await _menuService.GetAllPizzas();
            return Ok(ty);
        }
    }
}
