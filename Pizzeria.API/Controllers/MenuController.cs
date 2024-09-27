using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Interfaces;

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

        [HttpGet("get-all-pizza")]
        public IActionResult GetAllPizza()
        {
            return Ok();
        }
    }
}
