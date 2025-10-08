namespace AIM.BookStoreManagement.DB.Entities;

public class Users
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public DateTime? LastLogin { get; set; }
}