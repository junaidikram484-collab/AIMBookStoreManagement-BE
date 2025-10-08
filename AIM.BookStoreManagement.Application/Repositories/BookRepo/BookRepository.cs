
using AIM.BookStoreManagement.DB.Context;
using AIM.BookStoreManagement.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIM.BookStoreManagement.Application.Repositories.BookRepo;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.Include(x => x.Author).ToListAsync();
    }

    public async Task<Book> GetByIdAsync(Guid id)
    {
        return await _context.Books.Include(x => x.Author).FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetByAuthorAsync(Guid authorId)
    {
        return await _context.Books.Include(x => x.Author).Where(b => b.AuthorId == authorId).ToListAsync();
    }

    public async Task<Book> AddAsync(Book book)
    {
        if (book.Id == Guid.Empty)
        {
            book.Id = Guid.NewGuid();
        }
        // Ensure the Author object is attached for the return DTO (in service)
        book.Author = _context.Authors.FirstOrDefault(a => a.Id == book.AuthorId);

        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateAsync(Book updatedBook)
    {
        var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == updatedBook.Id);
        if (existingBook == null)
        {
            return existingBook;
        }

        existingBook.Title = updatedBook.Title;
        existingBook.YearPublished = updatedBook.YearPublished;
        existingBook.Pages = updatedBook.Pages;

        // Attach author
        existingBook.Author = _context.Authors.FirstOrDefault(a => a.Id == existingBook.AuthorId);
        await _context.SaveChangesAsync();
        return existingBook;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var bookToRemove = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (bookToRemove == null)
        {
            return false;
        }

        _context.Books.Remove(bookToRemove);
        await _context.SaveChangesAsync();
        return true;
    }
}