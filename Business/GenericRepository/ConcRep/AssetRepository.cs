using Business.GenericRepository.BaseRep;
using Business.GenericRepository.IntRep;
using DataAccess;
using Domain.Model;

namespace Business.GenericRepository.ConcRep;

public class AssetRepository : BaseRepository<Asset>, IAssetRepository
{
    public AssetRepository(Zero2StocksContext db) : base(db)
    {
        
    }
}
