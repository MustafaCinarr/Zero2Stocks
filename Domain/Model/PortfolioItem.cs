using Core.Domain;

namespace Domain.Model;

public class PortfolioItem : BaseEntity
{
    public int PortfolioId { get; set; }

    public Portfolio? Portfolio { get; set; }

    public int AssetId { get; set; }

    public Asset? Asset { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? AveragePrice { get; set; }
}
