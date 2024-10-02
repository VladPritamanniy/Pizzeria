using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class IngredientDto : BaseDto
    {
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
    }
}
