using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Application.Services.AuthorServ;

public interface IAuthorService
{
    // R - Read
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto> GetAuthorByIdAsync(Guid id);

    // C - Create
    Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto newAuthorDto);

    // U - Update
    Task<AuthorDto> UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto);

    // D - Delete
    Task<bool> DeleteAuthorAsync(Guid id);
}