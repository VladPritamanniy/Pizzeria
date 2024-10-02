using Pizzeria.Core.Repositories.Base;

namespace Pizzeria.Core.Repositories
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
