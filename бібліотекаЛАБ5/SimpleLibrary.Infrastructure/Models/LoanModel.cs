namespace SimpleLibrary.Infrastructure.Models;

public class LoanModel
{
    public int Id { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int ReaderId { get; set; }

    public ReaderModel Reader { get; set; } = null!;

    public int LibraryItemId { get; set; }

    public LibraryItemModel LibraryItem { get; set; } = null!;
}