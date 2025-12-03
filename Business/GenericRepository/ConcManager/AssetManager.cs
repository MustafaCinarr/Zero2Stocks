using AutoMapper;
using Business.DTOs.Asset;
using Business.GenericRepository.IntRep;
using Business.GenericRepository.IntServices;
using Domain.Model;

namespace Business.GenericRepository.ConcManager;

public class AssetManager : IAssetService
{
    private readonly IAssetRepository _assetRepository;
    private readonly IMapper _mapper;

    public AssetManager(IAssetRepository assetRepository, IMapper mapper)
    {
        _assetRepository = assetRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AssetGetDto>> GetAllAsync()
    {
        var assets = await _assetRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AssetGetDto>>(assets);
    }

    public async Task<AssetGetDto> GetByIdAsync(int id)
    {
        var asset = await _assetRepository.FindAsync(id);
        return asset == null ? null! : _mapper.Map<AssetGetDto>(asset);
    }

    public async Task<AssetGetDto> AddAsync(AssetCreateDto createDto)
    {
        var entity = _mapper.Map<Asset>(createDto);
        await _assetRepository.AddAsync(entity);
        return _mapper.Map<AssetGetDto>(entity);
    }

    public async Task<bool> UpdateAsync(int id, AssetUpdateDto updateDto)
    {
        var existing = await _assetRepository.FindAsync(id);
        if (existing == null)
        {
            return false;
        }

        _mapper.Map(updateDto, existing);
        await _assetRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _assetRepository.FindAsync(id);
        if (existing == null)
        {
            return false;
        }

        // MemberManager’da DestroyAsync kullanmıştın, aynı mantığı burada da devam ettiriyorum.
        await _assetRepository.DestroyAsync(id);
        // Soft delete istersek ileride DeleteAsync'e çevirebiliriz.
        return true;
    }
}