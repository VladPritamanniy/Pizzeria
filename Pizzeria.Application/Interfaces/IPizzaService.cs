using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Interfaces
{
    public interface IPizzaService
    {
        Task<List<PizzaDisplayOrderingDto>> GetPizzaForChangingDisplayOrder();
        Task CreatePizza(PizzaCreateDto dto);
        Task ChangePizzaDisplayOrdering(List<PizzaDisplayOrderingDto> dto);
    }
}
