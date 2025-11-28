using AutoMapper;
using Business.DTOs.PortfolioItem;
using Domain.Model;

namespace Business.Mapper;

public class PortfolioItemMapping : Profile
{
    public PortfolioItemMapping()
    {
        CreateMap<PortfolioItem, PortfolioItemGetDto>().ReverseMap();
        CreateMap<PortfolioItem, PortfolioItemCreateDto>().ReverseMap();
        CreateMap<PortfolioItem, PortfolioItemUpdateDto>().ReverseMap();
    }
}
