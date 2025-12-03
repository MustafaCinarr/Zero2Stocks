using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Model;
using Business.GenericRepository.IntRep;

namespace Business.GenericRepository.ConcRep;

public class PortfolioRepository : BaseRepository<Portfolio>, IPortfolioRepository
{
    public PortfolioRepository(Zero2StocksContext db) : base(db)
    {
        
    }
}
