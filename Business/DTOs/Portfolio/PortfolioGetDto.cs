namespace Business.DTOs.Portfolio;

public class PortfolioGetDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int MemberId { get; set; }

    public int ItemCount { get; set; }
}
