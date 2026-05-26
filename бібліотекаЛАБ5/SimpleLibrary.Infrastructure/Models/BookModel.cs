namespace SimpleLibrary.Infrastructure.Models;

public class BookModel : LibraryItemModel
{
    public string Author { get; set; } = string.Empty;

    public int Pages { get; set; }

    public string Genre { get; set; } = string.Empty;
}