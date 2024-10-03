using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class SizeWithPriceDto : BaseDto
    {
        public string Name { get; set; }
        public int Diameter { get; set; }
        public string Price { get; set; }
    }
}
