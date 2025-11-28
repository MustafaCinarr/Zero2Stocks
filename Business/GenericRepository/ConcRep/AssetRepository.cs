using Business.GenericRepository.BaseRep;
using Business.GenericRepository.IntRep;
using DataAccess;
using Domain.Model;

namespace Business.GenericRepository.ConcRep;

public class AssetRepository : BaseRepository<Asset>, IRepository<Asset>
{
    public AssetRepository(BusinessPartnerContext db) : base(db)
    {
    }
}
