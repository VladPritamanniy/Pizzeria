using Pizzeria.Core.Entities;
using Pizzeria.Core.Specifications.Base;

namespace Pizzeria.Core.Specifications
{
    public class PizzaSelectSpecification : Specification<Pizza, Pizza>
    {
        public PizzaSelectSpecification()
        {
            ApplySelector(p=> new()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder
            });
            ApplyOrderBy(p => p.DisplayOrder);
            ApplyAsNoTracking(true);
        }
    }
}
