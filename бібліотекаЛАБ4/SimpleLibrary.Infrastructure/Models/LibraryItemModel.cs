namespace SimpleLibrary.Infrastructure.Models;

public abstract class LibraryItemModel
{
    public int Id { get; set; }

    public Guid OriginalId { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Year { get; set; }

    public bool IsAvailable { get; set; }

    public ICollection<LoanModel> Loans { get; set; } = new List<LoanModel>();
}