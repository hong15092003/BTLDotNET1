using BTLDotNET1.Helpers;
using BTLDotNET1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BTLDotNET1.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly QLSBDTContext _context;
        private readonly DbSet<T> _dbSet;
        private ExceptionMessage exceptionMessage = new ExceptionMessage();

        public GenericRepository(QLSBDTContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T?> GetByCodeAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetByNameAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                exceptionMessage.Exception(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                exceptionMessage.Exception(ex);
                return false;
            }
        }

        public async Task<bool> AddOrUpdateAsync(T entity)
        {
            try
            {
                var entry = _context.Entry(entity);
                switch (entry.State)
                {
                    case EntityState.Detached:
                        await AddAsync(entity);
                        break;
                    case EntityState.Modified:
                        await UpdateAsync(entity);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                exceptionMessage.Exception(ex);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                //do something
                var entity = await GetByIdAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                exceptionMessage.Exception(ex);
                return false;
            }
        }
    }
}

