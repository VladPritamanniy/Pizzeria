using Pizzeria.Application.DTO.Base;

namespace Pizzeria.Application.DTO
{
    public class SizeDto : BaseDto
    {
        public string Name { get; set; }
        public int Diameter { get; set; }
    }
}
