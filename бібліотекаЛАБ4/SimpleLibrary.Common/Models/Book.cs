namespace SimpleLibrary.Common.Models;

public class Book : LibraryItem
{
    public string Author { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }

    // конструктор
    public Book(string title, int year, bool isAvailable, string author, int pages, string genre)
        : base(title, year, isAvailable)
    {
        Author = author;
        Pages = pages;
        Genre = genre;
    }

    // статичний метод створення нового об'єкта з випадковими даними
    public static Book CreateNew()
    {
        Random random = new Random();

        return new Book(
            "Книга " + random.Next(1, 10000),
            random.Next(1950, 2026),
            true,
            "Автор " + random.Next(1, 100),
            random.Next(100, 1000),
            "Жанр " + random.Next(1, 10)
        );
    }

    // метод
    public override string GetInfo()
    {
        return $"Назва: {Title} | Автор: {Author} | Рік: {Year} | Жанр: {Genre} | Сторінок: {Pages}";
    }
}