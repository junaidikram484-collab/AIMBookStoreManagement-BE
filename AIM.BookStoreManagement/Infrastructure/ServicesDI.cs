using AIM.BookStoreManagement.Application.Repositories.AuthorRepo;
using AIM.BookStoreManagement.Application.Repositories.BookRepo;
using AIM.BookStoreManagement.Application.Repositories.UserRepo;
using AIM.BookStoreManagement.Application.Services.AuthorServ;
using AIM.BookStoreManagement.Application.Services.BookServ;
using AIM.BookStoreManagement.Application.Services.UserServ;
using AIM.BookStoreManagement.JWT;

namespace AIM.BookStoreManagement.Infrastructure;

public static class ServicesDI
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthorRepository, AuthorRepository>()
            .AddScoped<IAuthorService, AuthorService>()
            .AddTransient<IBookRepository, BookRepository>()
            .AddScoped<IBookService, BookService>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddTransient<IJwtService,JwtService>();
    }
}