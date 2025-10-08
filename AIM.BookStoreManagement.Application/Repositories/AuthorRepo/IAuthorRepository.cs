using AIM.BookStoreManagement.DB.Entities;

namespace AIM.BookStoreManagement.Application.Repositories.AuthorRepo;

public interface IAuthorRepository
{
    // R - Read
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author> GetByIdAsync(Guid id);

    // CUD - Create, Update, Delete
    Task AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(Guid id);
}

