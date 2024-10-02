using Pizzeria.Core.Repositories.Base;

namespace Pizzeria.Core.Repositories
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
