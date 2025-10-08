using AIM.BookStoreManagement.DB.Entities;
using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Extensions;

public static class BookTransformer
{
    public static BookDto ToBookDto(this Book book)
    {
        if (book == null) return null;

        // Manual Mapping from Book Entity to BookDto
        var dto = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Year = book.YearPublished,
            Pages = book.Pages,
        };

        if (book.Author != null)
        {
            dto.Author = new AuthorDto
            {
                Id = book.Author.Id,
                Name = book.Author.Name,
                BioGraphy = book.Author.BioGraphy
            };
        }
        return dto;
    }

    public static List<BookDto> ToBookDto(this List<Book> books)
    {
        var booksDto = new List<BookDto>();
        foreach (var book in books)
        {
            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.YearPublished,
                Pages = book.Pages,
            };

            if (book.Author != null)
            {
                bookDto.Author = new AuthorDto
                {
                    Id = book.Author.Id,
                    Name = book.Author.Name,
                    BioGraphy = book.Author.BioGraphy
                };
            }

            booksDto.Add(bookDto);
        }
        
        return booksDto;
    }
}