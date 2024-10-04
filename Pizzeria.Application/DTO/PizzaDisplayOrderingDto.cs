using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class PizzaDisplayOrderingDto : BaseDto
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
