using Pizzeria.Core.Entities.Base;

namespace Pizzeria.Core.Entities
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }
        public int Diameter { get; set; }
    }
}
