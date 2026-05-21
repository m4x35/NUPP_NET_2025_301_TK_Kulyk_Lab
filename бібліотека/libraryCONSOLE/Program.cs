using SimpleLibrary.Common.Models;
using SimpleLibrary.Common.Services;

var service = new InMemoryCrudService<Book>();

var book1 = new Book("Кобзар", 1840, true, "Тарас Шевченко", 250, "Поезія");

var book2 = new Book("Лісова пісня", 1911, true, "Леся Українка", 180, "Драма");

service.Create(book1);
service.Create(book2);

Console.WriteLine("=== Книги після додавання ===");

foreach (var book in service.ReadAll())
{
    Console.WriteLine(book.GetInfo());
}

book1.Pages = 300;
service.Update(book1);

Console.WriteLine("\n=== Книги після оновлення ===");

foreach (var book in service.ReadAll())
{
    Console.WriteLine(book.GetInfo());
}

service.Remove(book2);

Console.WriteLine("\n=== Книги після видалення ===");

foreach (var book in service.ReadAll())
{
    Console.WriteLine(book.GetInfo());
}

Console.ReadKey();