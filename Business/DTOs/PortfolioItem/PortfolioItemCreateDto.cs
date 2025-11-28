namespace Business.DTOs.PortfolioItem;

public class PortfolioItemCreateDto
{
    public int PortfolioId { get; set; }

    public int AssetId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? AveragePrice { get; set; }
}
