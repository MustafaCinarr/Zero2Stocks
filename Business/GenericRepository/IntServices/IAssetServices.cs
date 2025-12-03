using Business.DTOs.Asset;
using Business.GenericRepository.IntServices.IBaseService;  // <— senin IBaseService namespace’in bu

namespace Business.GenericRepository.IntServices           
{
    public interface IAssetService 
        : IBaseService<AssetGetDto, AssetCreateDto, AssetUpdateDto>
    {
        
    }
}

