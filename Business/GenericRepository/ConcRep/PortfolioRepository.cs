using Business.GenericRepository.BaseRep;
using Business.GenericRepository.IntRep;
using DataAccess;
using Domain.Model;

namespace Business.GenericRepository.ConcRep;

public class PortfolioRepository : BaseRepository<Portfolio>, IRepository<Portfolio>
{
    public PortfolioRepository(BusinessPartnerContext db) : base(db)
    {
    }
}
