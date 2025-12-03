using Business.GenericRepository.BaseRep;
using DataAccess;
using Domain.Model;
using Business.GenericRepository.IntRep;

namespace Business.GenericRepository.ConcRep;

public class MemberRepository : BaseRepository<Member>, IMemberRepository
{
    public MemberRepository(Zero2StocksContext db) : base(db)
    {
    }
}
