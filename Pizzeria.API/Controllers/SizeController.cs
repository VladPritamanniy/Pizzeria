using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSizes()
        {
            return Ok(await _sizeService.GetAllSizes());
        }
    }
}
