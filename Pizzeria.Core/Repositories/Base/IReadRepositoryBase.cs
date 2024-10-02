using Pizzeria.Core.Specifications.Base;

namespace Pizzeria.Core.Repositories.Base
{
    public interface IReadRepositoryBase<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ToListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TResult>> ToListAsync<TResult>(ISpecification<T, TResult> spec, CancellationToken cancellationToken = default);
        Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);
        Task<T?> SingleOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<TResult?> SingleOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<TResult[]?> ToArrayAsync<TResult>(ISpecification<T, TResult> spec, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    }
}
