namespace SimpleLibrary.Common.Models;

public class Book : LibraryItem
{
    public string Author { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
    public Book(string title, int year, bool isAvailable, string author, int pages, string genre)
        : base(title, year, isAvailable)
    {
        Author = author;
        Pages = pages;
        Genre = genre;
    }

    public override string GetInfo()
    {
        return $"Назва: {Title} | Автор: {Author} | Рік: {Year} | Жанр: {Genre} | Сторінок: {Pages}";
    }
}
