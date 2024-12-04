using System.Linq.Expressions;

namespace BTLDotNET1.Services
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByCodeAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> AddOrUpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
    }
}
