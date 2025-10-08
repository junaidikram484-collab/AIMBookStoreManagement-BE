namespace AIM.BookStoreManagement.Dto.DTO;

public class CreateBookInput
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }
    public Guid AuthorId { get; set; }
}