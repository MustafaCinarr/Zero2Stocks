namespace Business.DTOs.Member;

public class MemberGetDto
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public int PortfolioCount { get; set; }

    public int CommentCount { get; set; }
}
