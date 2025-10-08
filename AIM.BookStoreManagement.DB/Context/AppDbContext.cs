using AIM.BookStoreManagement.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;

namespace AIM.BookStoreManagement.DB.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // DbSet properties represent the tables in your database
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the primary keys (optional, as EF Core conventions usually handle Guid Ids)
        modelBuilder.Entity<Author>().HasKey(a => a.Id);
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<Users>().HasKey(u => u.Id);

        // Configure the One-to-Many Relationship explicitly
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)       // A Book has one Author
            .WithMany(a => a.Books)      // An Author has many Books
            .HasForeignKey(b => b.AuthorId) // Use the AuthorId as the Foreign Key
            .OnDelete(DeleteBehavior.Cascade); // If an Author is deleted, their Books are also deleted

        // Mock data seeding for testing purposes
        var authorId1 = new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b3");
        var authorId2 = new Guid("c3f0f7f0-0220-42b7-a859-00100a7d97b4");

        modelBuilder.Entity<Author>().HasData(
            new Author { Id = authorId1, Name = "Terry Pratchett", BioGraphy = "The late, great fantasy author." },
            new Author { Id = authorId2, Name = "Ursula K. Le Guin", BioGraphy = "Master of social science fiction." }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = Guid.NewGuid(), Title = "Guards! Guards!", YearPublished = 1989, AuthorId = authorId1 },
            new Book { Id = Guid.NewGuid(), Title = "A Wizard of Earthsea", YearPublished = 1968, AuthorId = authorId2 }
        );

        modelBuilder.Entity<Users>().HasData(
            new Users
            {
                Id = Guid.NewGuid(),
                Username = "aim_admin",
                Name = "admin",
                Password = "Test@321"
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}