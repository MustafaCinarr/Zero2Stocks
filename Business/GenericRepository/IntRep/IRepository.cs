using Core.Domain;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.GenericRepository.IntRep;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();

    Task<T?> FindAsync(int id);

    Task AddAsync(T item);

    Task AddRangeAsync(IEnumerable<T> items);

    Task UpdateAsync(T item);

    Task UpdateRangeAsync(IEnumerable<T> items);

    Task DeleteAsync(int id);

    Task DeleteRangeAsync(IEnumerable<int> ids);

    Task DestroyAsync(int id);

    Task DestroyRangeAsync(IEnumerable<int> ids);

    Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    Task<List<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector);

    Task<List<TResult>> SelectAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);
}
