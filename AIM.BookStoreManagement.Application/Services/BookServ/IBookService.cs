using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Application.Services.BookServ;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooksAsync();
    Task<BookDto> GetBookByIdAsync(Guid id);
    Task<List<BookDto>> GetBooksByAuthorAsync(Guid authorId);
    Task<BookDto> CreateBookAsync(CreateBookInput input);
    Task<BookDto> UpdateBookAsync(UpdateBookInput input);
    Task<bool> DeleteBookAsync(Guid id);
}