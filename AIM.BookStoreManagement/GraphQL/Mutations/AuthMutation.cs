using AIM.BookStoreManagement.Application.Services.UserServ;
using AIM.BookStoreManagement.Dto.DTO;
using AIM.BookStoreManagement.JWT;

namespace AIM.BookStoreManagement.GraphQL.Mutations;

[MutationType]
public class AuthMutation
{
    public async Task<LoginDto> Login(LoginRequestDto login, [Service] IUserService userService, [Service]IJwtService jwtService)
    {
        var user = await userService.GetUserByUserName(login.UserName);

        if (user == null) throw new UnauthorizedAccessException(message: "Invalid username or password.");
        if(!user.Password.Equals(login.Password)) throw new UnauthorizedAccessException(message: "Invalid username or password.");

        var token = jwtService.GenerateToken(user);

        return new LoginDto()
        {
            Token = token,
            UserInfo = user
        };
    }
}
