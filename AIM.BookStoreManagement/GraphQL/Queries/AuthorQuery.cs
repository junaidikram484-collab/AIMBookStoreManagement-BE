using AIM.BookStoreManagement.Application.Services.AuthorServ;
using AIM.BookStoreManagement.Dto.DTO;
using HotChocolate.Authorization;

namespace AIM.BookStoreManagement.GraphQL.Queries;

[QueryType]
public class AuthorQuery
{
    [Authorize]
    public Task<IEnumerable<AuthorDto>> GetAuthors([Service] IAuthorService authorService)
    {
        return authorService.GetAuthorsAsync();
    }

    [Authorize]
    public Task<AuthorDto> GetAuthor(Guid id, [Service] IAuthorService authorService)
    {
        return authorService.GetAuthorByIdAsync(id);
    }
}