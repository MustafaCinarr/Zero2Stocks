using Domain.Enums;

namespace Business.DTOs.Asset;

public class AssetCreateDto
{
    public string Symbol { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public AssetType Type { get; set; }
}
