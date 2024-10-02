using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class OrderPizza : BaseEntity
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }

        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
        public Size Size { get; set; }
        public HashSet<OrderPizzaAdditionalIngredient> AdditionalIngredients { get; set; }
    }
}
