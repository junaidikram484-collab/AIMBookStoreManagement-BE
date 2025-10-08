using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Application.Services.UserServ;

public interface IUserService
{
    Task<UserDto> GetUserByUserName(string userName);
    Task<bool> ValidateCredentials(LoginRequestDto login);
}