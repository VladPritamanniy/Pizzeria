using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class OrderPizzaAdditionalIngredient : BaseEntity
    {
        public int OrderPizzaId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }

        public OrderPizza OrderPizza { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
