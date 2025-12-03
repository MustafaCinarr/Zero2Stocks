using System.Linq.Expressions;
using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Model;
using Business.GenericRepository.IntRep;
using Microsoft.EntityFrameworkCore;

namespace Business.GenericRepository.ConcRep;

public class PortfolioItemRepository : BaseRepository<PortfolioItem>, IPortfolioItemRepository
{
    public PortfolioItemRepository(Zero2StocksContext db) : base(db)
    {
        
    }

    public override async Task<List<PortfolioItem>> GetAllAsync()
    {
        return await _table
            .Include(x=>x.Asset)
            .Where(x=>!x.Deleted)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<PortfolioItem?> FindAsync(int id)
    {
        return await _table
            .Include(x => x.Asset)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
    }

    public override async Task<List<PortfolioItem>> WhereAsync(Expression<Func<PortfolioItem, bool>> predicate)
    {
        return await _table
            .Include(x => x.Asset)
            .Where(x=> !x.Deleted)  // soft delete filtresi
            .Where(predicate)
            .AsNoTracking()
            .ToListAsync();
    }
    
}
