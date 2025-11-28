using Business.GenericRepository.BaseRep;
using Business.GenericRepository.IntRep;
using DataAccess;
using Domain.Model;

namespace Business.GenericRepository.ConcRep;

public class MemberRepository : BaseRepository<Member>, IRepository<Member>
{
    public MemberRepository(BusinessPartnerContext db) : base(db)
    {
    }
}
