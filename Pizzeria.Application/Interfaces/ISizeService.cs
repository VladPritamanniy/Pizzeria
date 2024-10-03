using Pizzeria.Application.DTO;

namespace Pizzeria.Application.Interfaces
{
    public interface ISizeService
    {
        Task<List<SizeDto>> GetAllSizes();
    }
}
