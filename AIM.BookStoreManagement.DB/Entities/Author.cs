namespace AIM.BookStoreManagement.DB.Entities;

public class Author
{
    public Guid Id { get; set; } // Primary Key
    public string Name { get; set; }
    public string? BioGraphy { get; set; }

    // Navigation Property: One Author can have many Books
    public ICollection<Book> Books { get; set; } = new List<Book>();
}