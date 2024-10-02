using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class PizzaPrice : BaseEntity
    {
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public int PriceId { get; set; }

        public Size Size { get; set; }
        public Price Price { get; set; }
    }
}
