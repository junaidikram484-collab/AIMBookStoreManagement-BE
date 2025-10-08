using AIM.BookStoreManagement.Dto.DTO;

namespace AIM.BookStoreManagement.JWT;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}