using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Interfaces
{
    public interface IMenuService
    {
        Task<MenuDto> GetAllPizzas();
    }
}
