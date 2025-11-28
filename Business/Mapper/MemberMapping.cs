using AutoMapper;
using Business.DTOs.Member;
using Domain.Model;

namespace Business.Mapper;

public class MemberMapping : Profile
{
    public MemberMapping()
    {
        CreateMap<Member, MemberGetDto>().ReverseMap();
        CreateMap<Member, MemberCreateDto>().ReverseMap();
        CreateMap<Member, MemberUpdateDto>().ReverseMap();
    }
}
