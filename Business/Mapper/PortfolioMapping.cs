using AutoMapper;
using Business.DTOs.Portfolio;
using Domain.Model;

namespace Business.Mapper;

public class PortfolioMapping : Profile
{
    public PortfolioMapping()
    {
        CreateMap<Portfolio, PortfolioGetDto>().ReverseMap();
        CreateMap<Portfolio, PortfolioCreateDto>().ReverseMap();
        CreateMap<Portfolio, PortfolioUpdateDto>().ReverseMap();
    }
}
