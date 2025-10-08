using System.Reflection.Metadata.Ecma335;
using AIM.BookStoreManagement.Application.Extensions;
using AIM.BookStoreManagement.Application.Repositories.UserRepo;
using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.Application.Services.UserServ;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> GetUserByUserName(string userName)
    {
        return (await _userRepository.GetUser(userName)).ToUserDto();
    }

    public async Task<bool> ValidateCredentials(LoginRequestDto login)
    {
        var user = await _userRepository.GetUser(login.UserName);
        if (user == null) return false;

        return user.Password.Equals(login.Password);
    }
}