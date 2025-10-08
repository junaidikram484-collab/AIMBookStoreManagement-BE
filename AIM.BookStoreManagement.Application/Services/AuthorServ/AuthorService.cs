using AIM.BookStoreManagement.Application.Repositories.AuthorRepo;
using AIM.BookStoreManagement.DB.Entities;
using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Application.Services.AuthorServ;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    // Helper method to map Entity to DTO
    private AuthorDto MapToDto(Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            BioGraphy = author.BioGraphy
        };
    }

    // R - Read Implementations (Existing)
    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        var authors = await _repository.GetAllAsync();
        return authors.Select(a => MapToDto(a));
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
    {
        var author = await _repository.GetByIdAsync(id);

        if (author == null) return null;

        return MapToDto(author);
    }

    // C - Create Implementation
    public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto newAuthorDto)
    {
        // Add business logic/validation here if needed
        var author = new Author
        {
            Id = Guid.NewGuid(),
            Name = newAuthorDto.Name,
            BioGraphy = newAuthorDto.BioGraphy
        };

        await _repository.AddAsync(author);
        return MapToDto(author);
    }

    // U - Update Implementation
    public async Task<AuthorDto> UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto)
    {
        var existingAuthor = await _repository.GetByIdAsync(updateAuthorDto.Id);

        if (existingAuthor == null) return null;

        existingAuthor.Name = updateAuthorDto.Name;
        existingAuthor.BioGraphy = updateAuthorDto.BioGraphy;

        await _repository.UpdateAsync(existingAuthor);
        return MapToDto(existingAuthor);
    }

    // D - Delete Implementation
    public async Task<bool> DeleteAuthorAsync(Guid id)
    {
        var existingAuthor = await _repository.GetByIdAsync(id);
        if (existingAuthor == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}