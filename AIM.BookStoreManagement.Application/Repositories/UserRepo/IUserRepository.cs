using AIM.BookStoreManagement.DB.Context;
using AIM.BookStoreManagement.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIM.BookStoreManagement.Application.Repositories.UserRepo;

public interface IUserRepository
{
    Task<Users> GetUser(string userName);
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Users> GetUser(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(userName));
    }
}