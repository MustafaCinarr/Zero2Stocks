namespace Business.DTOs.PortfolioItem;

public class PortfolioItemGetDto
{
    public int Id { get; set; }
    public int PortfolioId { get; set; }
    public int AssetId { get; set; }

    public string Symbol { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public decimal? Quantity { get; set; }

    public decimal? AveragePrice { get; set; }
    
    // Pyhton'dan gelen veriyle dolacak olan bilgiler
    
    public decimal LastPrice { get; set; }
    public decimal CurrentValue { get; set; } // Quantity * LastPrice
    public decimal PnL  { get; set; } // (LastPrice - AveragePrice) * Quantity
    
}
