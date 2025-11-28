using Domain.Enums;

namespace Business.DTOs.Asset;

public class AssetGetDto
{
    public int Id { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public AssetType Type { get; set; }

    public int PortfolioItemCount { get; set; }

    public int CommentCount { get; set; }
}
