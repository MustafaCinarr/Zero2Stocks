namespace Business.DTOs.AssetComment;

public class AssetCommentUpdateDto
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int AssetId { get; set; }

    public string Content { get; set; } = string.Empty;
}
