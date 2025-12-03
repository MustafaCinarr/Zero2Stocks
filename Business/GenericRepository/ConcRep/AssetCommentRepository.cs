using Business.GenericRepository.BaseRep;
using Business.GenericRepository.IntRep;
using DataAccess;
using Domain.Model;

namespace Business.GenericRepository.ConcRep;

public class AssetCommentRepository : BaseRepository<AssetComment>, IRepository<AssetComment>
{
    public AssetCommentRepository(Zero2StocksContext db) : base(db)
    {
    }
}
