using Pizzeria.Core.Entities;
using Pizzeria.Core.Specifications.Base;

namespace Pizzeria.Core.Specifications
{
    public class PizzaSpecification : Specification<Pizza>
    {
        public PizzaSpecification()
        {
            AddInclude(p=>p.PizzaIngredients);
            AddInclude(p => p.PizzaPrices);
            ApplyOrderBy(p=>p.DisplayOrder);
            ApplyAsNoTracking(true);
            ApplyAsSplitQuery(true);
        }
    }
}
