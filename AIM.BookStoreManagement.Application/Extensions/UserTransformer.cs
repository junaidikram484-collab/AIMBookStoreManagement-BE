using AIM.BookStoreManagement.DB.Entities;
using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Application.Extensions;

public static class UserTransformer
{
    public static UserDto ToUserDto(this Users user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            UserName = user.Username,
            Password = user.Password,
            LastLogin = user.LastLogin
        };
    }
}