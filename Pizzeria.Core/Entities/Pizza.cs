using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public string PublicImageId { get; set; }
        public int? DisplayOrder { get; set; }

        public HashSet<PizzaIngredient> PizzaIngredients { get; set; }
        public HashSet<PizzaPrice> PizzaPrices { get; set; }
    }
}
