using SimpleLibrary.Common.Models;
using SimpleLibrary.Common.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var service = new InMemoryCrudServiceAsync<Book>("books.json");

Console.WriteLine("=== Лабораторна робота №2 ===");
Console.WriteLine("Асинхронний thread-safe CRUD сервіс");
Console.WriteLine();

var tasks = Enumerable.Range(0, 1000)
    .Select(async _ =>
    {
        await service.CreateAsync(Book.CreateNew());
    });

await Task.WhenAll(tasks);

var books = (await service.ReadAllAsync()).ToList();

Console.WriteLine($"Створено книг: {books.Count}");
Console.WriteLine();

Console.WriteLine("=== Статистика по сторінках ===");
Console.WriteLine($"Мінімальна кількість сторінок: {books.Min(x => x.Pages)}");
Console.WriteLine($"Максимальна кількість сторінок: {books.Max(x => x.Pages)}");
Console.WriteLine($"Середня кількість сторінок: {books.Average(x => x.Pages):F2}");

Console.WriteLine();

Console.WriteLine("=== Статистика по роках ===");
Console.WriteLine($"Найстаріша книга: {books.Min(x => x.Year)}");
Console.WriteLine($"Найновіша книга: {books.Max(x => x.Year)}");
Console.WriteLine($"Середній рік: {books.Average(x => x.Year):F2}");

Console.WriteLine();

Console.WriteLine("=== Приклад пагінації ===");
var firstPage = await service.ReadAllAsync(1, 5);

foreach (var book in firstPage)
{
    Console.WriteLine(book.GetInfo());
}

await service.SaveAsync();

Console.WriteLine();
Console.WriteLine("Колекцію збережено у файл books.json");

Console.WriteLine();
Console.WriteLine("=== Приклад AutoResetEvent ===");

AutoResetEvent autoResetEvent = new(false);

Thread thread = new(() =>
{
    Console.WriteLine("Потік очікує сигнал...");
    autoResetEvent.WaitOne();
    Console.WriteLine("Потік отримав сигнал і продовжив роботу.");
});

thread.Start();

Thread.Sleep(1000);

autoResetEvent.Set();

thread.Join();

Console.WriteLine();
Console.WriteLine("Роботу завершено.");

Console.ReadKey();