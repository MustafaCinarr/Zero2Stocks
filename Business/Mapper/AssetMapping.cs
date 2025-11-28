using AutoMapper;
using Business.DTOs.Asset;
using Domain.Model;

namespace Business.Mapper;

public class AssetMapping : Profile
{
    public AssetMapping()
    {
        CreateMap<Asset, AssetGetDto>().ReverseMap();
        CreateMap<Asset, AssetCreateDto>().ReverseMap();
        CreateMap<Asset, AssetUpdateDto>().ReverseMap();
    }
}
