using Core.Domain;

namespace Domain.Model;

public class AssetComment : BaseEntity
{
    public int MemberId { get; set; }

    public Member? Member { get; set; }

    public int AssetId { get; set; }

    public Asset? Asset { get; set; }

    public string Content { get; set; } = string.Empty;
}
