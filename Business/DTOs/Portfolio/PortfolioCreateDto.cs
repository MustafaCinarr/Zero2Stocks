namespace Business.DTOs.Portfolio;

public class PortfolioCreateDto
{
    public string Name { get; set; } = string.Empty;

    public int MemberId { get; set; }
}
