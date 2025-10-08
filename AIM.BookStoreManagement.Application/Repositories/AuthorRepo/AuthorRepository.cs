using AIM.BookStoreManagement.DB.Context;
using AIM.BookStoreManagement.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIM.BookStoreManagement.Application.Repositories.AuthorRepo;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    // R - Read Implementations
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetByIdAsync(Guid id)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
    }

    // C - Create Implementation
    public async Task AddAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
    }

    // U - Update Implementation
    public async Task UpdateAsync(Author author)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
    }

    // D - Delete Implementation
    public async Task DeleteAsync(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            // Delete associated books to maintain data integrity
            var books = await _context.Books.Where(b => b.AuthorId == id).ToListAsync();
            _context.Books.RemoveRange(books);
            await _context.SaveChangesAsync();
        }
    }
}