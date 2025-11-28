using Core.Domain;

namespace Domain.Model;

public class Portfolio : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int MemberId { get; set; }

    public Member? Member { get; set; }

    public ICollection<PortfolioItem> Items { get; set; } = new List<PortfolioItem>();
}
