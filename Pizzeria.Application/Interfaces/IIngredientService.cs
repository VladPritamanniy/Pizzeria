using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Interfaces
{
    public interface IIngredientService
    {
        Task<List<IngredientDto>> GetAllIngredients();
        Task<IngredientDto> CreateIngredient(IngredientDto dto);
    }
}
