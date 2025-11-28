using Business.GenericRepository.BaseRep;
using Business.GenericRepository.IntRep;
using DataAccess;
using Domain.Model;

namespace Business.GenericRepository.ConcRep;

public class PortfolioItemRepository : BaseRepository<PortfolioItem>, IRepository<PortfolioItem>
{
    public PortfolioItemRepository(BusinessPartnerContext db) : base(db)
    {
    }
}
