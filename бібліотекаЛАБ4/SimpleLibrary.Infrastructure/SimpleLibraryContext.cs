using Microsoft.EntityFrameworkCore;
using SimpleLibrary.Common.Models;
using SimpleLibrary.Infrastructure.Models;

namespace SimpleLibrary.Infrastructure;

public class SimpleLibraryContext : DbContext
{
    public DbSet<LibraryItemModel> LibraryItems => Set<LibraryItemModel>();
    public DbSet<BookModel> Books => Set<BookModel>();
    public DbSet<MagazineModel> Magazines => Set<MagazineModel>();
    public DbSet<ReaderModel> Readers => Set<ReaderModel>();
    public DbSet<LoanModel> Loans => Set<LoanModel>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=simple_library.db");
    }
}