using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class PizzaIngredient : BaseEntity
    {
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
