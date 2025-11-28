using Business.GenericRepository.IntRep;
using Core.Domain;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.GenericRepository.BaseRep;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly BusinessPartnerContext _db;
    protected readonly DbSet<T> _table;

    protected BaseRepository(BusinessPartnerContext db)
    {
        _db = db;
        _table = _db.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _table
            .Where(x => !x.Deleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<T?> FindAsync(int id)
    {
        return await _table
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
    }

    public virtual async Task AddAsync(T item)
    {
        item.CreatedAt = DateTime.UtcNow;
        item.Deleted = false;
        await _table.AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> items)
    {
        var utcNow = DateTime.UtcNow;
        foreach (var item in items)
        {
            item.CreatedAt = utcNow;
            item.Deleted = false;
        }

        await _table.AddRangeAsync(items);
        await _db.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T item)
    {
        item.UpdatedAt = DateTime.UtcNow;
        _table.Update(item);
        await _db.SaveChangesAsync();
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<T> items)
    {
        var utcNow = DateTime.UtcNow;
        foreach (var item in items)
        {
            item.UpdatedAt = utcNow;
        }

        _table.UpdateRange(items);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
        {
            return;
        }

        entity.Deleted = true;
        entity.DeletedAt = DateTime.UtcNow;
        _table.Update(entity);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<int> ids)
    {
        var entities = await _table.Where(x => ids.Contains(x.Id)).ToListAsync();
        var utcNow = DateTime.UtcNow;

        foreach (var entity in entities)
        {
            entity.Deleted = true;
            entity.DeletedAt = utcNow;
        }

        _table.UpdateRange(entities);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DestroyAsync(int id)
    {
        var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
        {
            return;
        }

        _table.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DestroyRangeAsync(IEnumerable<int> ids)
    {
        var entities = await _table.Where(x => ids.Contains(x.Id)).ToListAsync();
        _table.RemoveRange(entities);
        await _db.SaveChangesAsync();
    }

    public virtual async Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await _table
            .Where(x => !x.Deleted)
            .Where(predicate)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _table
            .Where(x => !x.Deleted)
            .AnyAsync(predicate);
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _table
            .Where(x => !x.Deleted)
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<List<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector)
    {
        return await _table
            .Where(x => !x.Deleted)
            .Select(selector)
            .ToListAsync();
    }

    public virtual async Task<List<TResult>> SelectAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
    {
        return await _table
            .Where(x => !x.Deleted)
            .Where(predicate)
            .Select(selector)
            .ToListAsync();
    }
}
