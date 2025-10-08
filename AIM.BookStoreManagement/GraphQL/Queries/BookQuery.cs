using AIM.BookStoreManagement.Application.Services.BookServ;
using AIM.BookStoreManagement.Dto.DTO;
using HotChocolate.Authorization;

namespace AIM.BookStoreManagement.GraphQL.Queries;

[QueryType]
public class BookQuery
{
    [Authorize]
    public Task<IEnumerable<BookDto>> GetBooks([Service] IBookService bookService)
    {
        return bookService.GetAllBooksAsync();
    }
    [Authorize]
    public Task<BookDto> GetBookById(Guid id, [Service] IBookService bookService)
    {
        return bookService.GetBookByIdAsync(id);
    }
    [Authorize]
    public async Task<List<BookDto>> GetBookByAuthor(Guid authorId, [Service] IBookService bookService)
    {
        return await bookService.GetBooksByAuthorAsync(authorId);
    }
}
