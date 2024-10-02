using Pizzeria.Core.Repositories;
using Pizzeria.Infrastructure.Repositories.Base;

namespace Pizzeria.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        public EfRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
