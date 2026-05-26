using Microsoft.EntityFrameworkCore;
using SimpleLibrary.Infrastructure;
using SimpleLibrary.Infrastructure.Models;
using SimpleLibrary.Infrastructure.Repositories;
using SimpleLibrary.Infrastructure.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var options = new DbContextOptionsBuilder<SimpleLibraryContext>()
    .UseSqlite("Data Source=simple_library.db")
    .Options;

using var context = new SimpleLibraryContext(options);

var repository = new Repository<BookModel>(context);
var service = new DatabaseCrudServiceAsync<BookModel>(repository);

Console.WriteLine("=== Лабораторна робота №5 ===");
Console.WriteLine("ASP.NET Core Identity + JWT + Roles"); ;