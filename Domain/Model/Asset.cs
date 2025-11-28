using Core.Domain;
using Domain.Enums;

namespace Domain.Model;

public class Asset : BaseEntity
{
    public string Symbol { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public AssetType Type { get; set; }

    public ICollection<PortfolioItem> PortfolioItems { get; set; } = new List<PortfolioItem>();

    public ICollection<AssetComment> Comments { get; set; } = new List<AssetComment>();
}
