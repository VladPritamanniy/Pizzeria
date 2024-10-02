using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class PizzaIngredientDto : BaseDto
    {
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }

        public IngredientDto Ingredient { get; set; }
    }
}
