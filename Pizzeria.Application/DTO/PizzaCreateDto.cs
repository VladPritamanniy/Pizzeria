using Microsoft.AspNetCore.Http;

namespace Pizzeria.Application.DTO
{
    public class PizzaCreateDto
    {
        public string Name { get; set; }
        public IFormFile PizzaImg { get; set; }
        public SizeWithPriceDto[] SizesWithPrice { get; set; }
        public int[] IngredientIds { get; set; }
    }
}
