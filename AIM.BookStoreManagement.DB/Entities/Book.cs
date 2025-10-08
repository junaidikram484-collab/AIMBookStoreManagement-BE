namespace AIM.BookStoreManagement.DB.Entities;

public class Book
{
    public Guid Id { get; set; } // Primary Key
    public string Title { get; set; }
    public int YearPublished { get; set; }
    public int Pages { get; set; }

    // Foreign Key: Links this Book to a single Author
    public Guid AuthorId { get; set; }

    // Navigation Property: The single Author for this Book
    public Author Author { get; set; }
}