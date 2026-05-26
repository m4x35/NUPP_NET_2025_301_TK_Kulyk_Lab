namespace SimpleLibrary.Common.Models;

public class LibraryItem : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

    // конструктор
    public LibraryItem(string title, int year, bool isAvailable)
    {
        Id = Guid.NewGuid();
        Title = title;
        Year = year;
        IsAvailable = isAvailable;
    }

    // метод
    public virtual string GetInfo()
    {
        return $"Id: {Id} | {Title} | Year: {Year} | Available: {IsAvailable}";
    }
}