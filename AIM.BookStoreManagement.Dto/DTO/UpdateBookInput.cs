namespace AIM.BookStoreManagement.Dto.DTO;

public class UpdateBookInput
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }
}