using Core.Domain;

namespace Domain.Model;

public class Member : BaseEntity
{
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    public ICollection<AssetComment> Comments { get; set; } = new List<AssetComment>();
}
