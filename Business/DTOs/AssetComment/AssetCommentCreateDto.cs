namespace Business.DTOs.AssetComment;

public class AssetCommentCreateDto
{
    public int MemberId { get; set; }

    public int AssetId { get; set; }

    public string Content { get; set; } = string.Empty;
}
