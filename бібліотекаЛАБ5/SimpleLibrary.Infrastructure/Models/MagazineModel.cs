namespace SimpleLibrary.Infrastructure.Models;

public class MagazineModel : LibraryItemModel
{
    public int IssueNumber { get; set; }

    public string Publisher { get; set; } = string.Empty;

    public string Topic { get; set; } = string.Empty;
}