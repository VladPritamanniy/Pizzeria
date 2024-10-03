using Pizzeria.Application.DTO;
using Pizzeria.Core.Entities;

namespace Pizzeria.Application.Interfaces
{
    public interface IPizzaFactory
    {
        Task<Pizza> Create(PizzaCreateDto dto);
    }
}
