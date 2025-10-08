using AIM.BookStoreManagement.DB.Entities;

namespace AIM.BookStoreManagement.Application.Repositories.BookRepo;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(Guid id);
    Task<List<Book>> GetByAuthorAsync(Guid authorId);
    Task<Book> AddAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<bool> DeleteAsync(Guid id);
}
