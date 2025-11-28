using AutoMapper;
using Business.DTOs.AssetComment;
using Domain.Model;

namespace Business.Mapper;

public class AssetCommentMapping : Profile
{
    public AssetCommentMapping()
    {
        CreateMap<AssetComment, AssetCommentGetDto>().ReverseMap();
        CreateMap<AssetComment, AssetCommentCreateDto>().ReverseMap();
        CreateMap<AssetComment, AssetCommentUpdateDto>().ReverseMap();
    }
}
