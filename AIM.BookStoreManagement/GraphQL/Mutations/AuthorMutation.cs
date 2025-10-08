using AIM.BookStoreManagement.Application.Services.AuthorServ;
using AIM.BookStoreManagement.Dto.DTO;
using HotChocolate.Authorization;

namespace AIM.BookStoreManagement.GraphQL.Mutations;

[MutationType]
public class AuthorMutation
{
    [Authorize]
    public Task<AuthorDto> CreateAuthor(CreateAuthorDto input, [Service] IAuthorService authorService)
    {
        return authorService.CreateAuthorAsync(input);
    }

    [Authorize]
    public Task<AuthorDto> UpdateAuthor(UpdateAuthorDto input, [Service] IAuthorService authorService)
    {
        // GraphQL convention suggests returning the modified object
        return authorService.UpdateAuthorAsync(input);
    }

    [Authorize]
    public async Task<bool> DeleteAuthor(Guid id, [Service] IAuthorService authorService)
    {
        // GraphQL convention suggests returning a boolean indicating success
        return await authorService.DeleteAuthorAsync(id);
    }
}