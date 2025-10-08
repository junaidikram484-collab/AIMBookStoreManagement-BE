using AIM.BookStoreManagement.Application.Repositories.BookRepo;
using AIM.BookStoreManagement.DB.Entities;
using AIM.BookStoreManagement.Dto.DTO;
using AIM.BookStoreManagement.Extensions;

namespace AIM.BookStoreManagement.Application.Services.BookServ;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await _repository.GetAllAsync();
        return books.ToList().ToBookDto();
    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _repository.GetByIdAsync(id);
        return book.ToBookDto();
    }

    public async Task<List<BookDto>> GetBooksByAuthorAsync(Guid authorId)
    {
        var book = await _repository.GetByAuthorAsync(authorId);
        return book.ToBookDto();
    }

    public async Task<BookDto> CreateBookAsync(CreateBookInput input)
    {
        var book = new Book
        {
            Title = input.Title,
            YearPublished = input.Year,
            Pages = input.Pages,
            AuthorId = input.AuthorId
        };

        // Note: The repository now handles saving to the real database
        var newBook = await _repository.AddAsync(book);
        return newBook.ToBookDto();
    }

    public async Task<BookDto> UpdateBookAsync(UpdateBookInput input)
    {
        // 1. Fetch the existing entity to get all properties (including AuthorId)
        var existingBook = await _repository.GetByIdAsync(input.Id);
        if (existingBook == null)
        {
            return null;
        }

        // 2. Update properties
        existingBook.Title = input.Title;
        existingBook.YearPublished = input.Year;
        existingBook.Pages = input.Pages;

        // 3. Save the updated entity
        var updatedBook = await _repository.UpdateAsync(existingBook);

        return updatedBook.ToBookDto();
    }

    public Task<bool> DeleteBookAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }
}