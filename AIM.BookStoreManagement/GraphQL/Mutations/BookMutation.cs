using AIM.BookStoreManagement.Application.Services.BookServ;
using AIM.BookStoreManagement.Dto.DTO;
using HotChocolate.Authorization;

namespace AIM.BookStoreManagement.GraphQL.Mutations;

[MutationType]
public class BookMutation
{
    [Authorize]
    public async Task<BookDto> AddBook(CreateBookInput input, [Service] IBookService bookService)
    {
        return await bookService.CreateBookAsync(input);
    }
    [Authorize]
    public async Task<BookDto> UpdateBook(UpdateBookInput input, [Service] IBookService bookService)
    {
        var updatedBook = await bookService.UpdateBookAsync(input);
        if (updatedBook == null)
        {
            throw new Exception($"Book with ID {input.Id} not found.");
        }
        return updatedBook;
    }
    [Authorize]
    public async Task<Guid> DeleteBook(Guid id, [Service] IBookService bookService)
    {
        var success = await bookService.DeleteBookAsync(id);
        if (!success)
        {
            throw new Exception($"Book with ID {id} not found.");
        }
        return id;
    }
}