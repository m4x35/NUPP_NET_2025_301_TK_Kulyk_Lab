using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleLibrary.Infrastructure.Models;

namespace SimpleLibrary.Infrastructure;

public class SimpleLibraryContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<LibraryItemModel> LibraryItems => Set<LibraryItemModel>();
    public DbSet<BookModel> Books => Set<BookModel>();
    public DbSet<MagazineModel> Magazines => Set<MagazineModel>();
    public DbSet<ReaderModel> Readers => Set<ReaderModel>();
    public DbSet<LoanModel> Loans => Set<LoanModel>();

    public SimpleLibraryContext(DbContextOptions<SimpleLibraryContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=simple_library.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<LoanModel>()
            .HasOne(l => l.Reader)
            .WithMany(r => r.Loans)
            .HasForeignKey(l => l.ReaderId);

        builder.Entity<LoanModel>()
            .HasOne(l => l.LibraryItem)
            .WithMany()
            .HasForeignKey(l => l.LibraryItemId);
    }
}