namespace SimpleLibrary.REST.Models;

public class BookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public bool IsAvailable { get; set; }
    public string Author { get; set; } = string.Empty;
    public int Pages { get; set; }
    public string Genre { get; set; } = string.Empty;
}