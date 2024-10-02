using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class PizzaDto : BaseDto
    {
        public string Name { get; set; }
        public string PublicImageId { get; set; }
        public int? DisplayOrder { get; set; }
        public HashSet<PizzaIngredientDto> PizzaIngredients { get; set; }
        public HashSet<PizzaPriceDto> PizzaPrices { get; set; }
    }
}
