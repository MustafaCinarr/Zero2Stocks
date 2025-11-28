namespace Business.DTOs.Portfolio;

public class PortfolioUpdateDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int MemberId { get; set; }
}
