using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
    }
}
