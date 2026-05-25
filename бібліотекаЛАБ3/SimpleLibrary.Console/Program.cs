using Microsoft.EntityFrameworkCore;
using SimpleLibrary.Infrastructure;
using SimpleLibrary.Infrastructure.Models;
using SimpleLibrary.Infrastructure.Repositories;
using SimpleLibrary.Infrastructure.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using var context = new SimpleLibraryContext();

await context.Database.MigrateAsync();

var repository = new Repository<BookModel>(context);

var service = new DatabaseCrudServiceAsync(repository);

Console.WriteLine("=== Лабораторна робота №3 ===");
Console.WriteLine("Entity Framework + SQLite + Repository");
Console.WriteLine();

if (!context.Books.Any())
{
    for (int i = 1; i <= 10; i++)
    {
        await service.CreateAsync(new BookModel
        {
            OriginalId = Guid.NewGuid(),
            Title = $"Книга {i}",
            Year = 2000 + i,
            IsAvailable = true,
            Author = $"Автор {i}",
            Pages = 100 + i * 20,
            Genre = $"Жанр {i}"
        });
    }

    var reader = new ReaderModel
    {
        OriginalId = Guid.NewGuid(),
        FullName = "Кулик Максим",
        Phone = "+380000000000",
        ReaderCardNumber = 301
    };

    context.Readers.Add(reader);

    await context.SaveChangesAsync();

    var firstBook = await context.Books.FirstAsync();

    context.Loans.Add(new LoanModel
    {
        LoanDate = DateTime.Now,
        ReaderId = reader.Id,
        LibraryItemId = firstBook.Id
    });

    await context.SaveChangesAsync();
}

var books = (await service.ReadAllAsync()).ToList();

Console.WriteLine($"Кількість книг у БД: {books.Count}");

Console.WriteLine();

foreach (var book in books)
{
    Console.WriteLine(
        $"Id: {book.Id} | " +
        $"{book.Title} | " +
        $"Автор: {book.Author} | " +
        $"Рік: {book.Year} | " +
        $"Сторінок: {book.Pages}");
}

Console.WriteLine();

Console.WriteLine("=== Пагінація ===");

var page = await service.ReadAllAsync(1, 5);

foreach (var book in page)
{
    Console.WriteLine($"{book.Id}. {book.Title}");
}

Console.WriteLine();

Console.WriteLine("=== Зв’язки Reader -> Loans -> Books ===");

var loans = await context.Loans
    .Include(x => x.Reader)
    .Include(x => x.LibraryItem)
    .ToListAsync();

foreach (var loan in loans)
{
    Console.WriteLine(
        $"Читач: {loan.Reader.FullName} | " +
        $"Книга: {loan.LibraryItem.Title} | " +
        $"Дата: {loan.LoanDate}");
}

Console.WriteLine();

Console.WriteLine("Базу даних SQLite створено успішно.");