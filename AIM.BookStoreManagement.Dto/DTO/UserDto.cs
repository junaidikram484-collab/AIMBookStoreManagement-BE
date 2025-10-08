namespace AIM.BookStoreManagement.Dto.DTO;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime? LastLogin { get; set; }
}