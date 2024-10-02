using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class PizzaPriceDto : BaseDto
    {
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public int PriceId { get; set; }

        public SizeDto Size { get; set; }
        public PriceDto Price { get; set; }
    }
}
