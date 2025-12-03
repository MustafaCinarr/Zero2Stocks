using AutoMapper;
using Business.DTOs.PortfolioItem;
using Domain.Model;

namespace Business.Mapper;

public class PortfolioItemMapping : Profile
{
    public PortfolioItemMapping()
    {
        CreateMap<PortfolioItem, PortfolioItemGetDto>()
            .ForMember(d=> d.Symbol, x => x.MapFrom(s => s.Asset!.Symbol))
            .ForMember(d => d.Name, x=> x.MapFrom(s=>s.Asset!.Name))
            .ReverseMap();
        CreateMap<PortfolioItem, PortfolioItemCreateDto>().ReverseMap();
        CreateMap<PortfolioItem, PortfolioItemUpdateDto>().ReverseMap();
    }
}
