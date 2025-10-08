using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AIM.BookStoreManagement.Infrastructure;

public static class AuthDI
{
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        // 1. ADD Authentication Services (Configure JWT options)
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("Issuer"), // Must match token
                    ValidAudience = Environment.GetEnvironmentVariable("Audience"), // Must match token
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JwtKey")!))
                };
            });

        //// Add Authorization Services
        //services.AddAuthorization(options =>
        //{
        //    // Define a policy for access to an admin route/type
        //    options.AddPolicy("RequireAdminRole", policy =>
        //        policy.RequireRole("Admin"));

        //    // Define a policy for general authenticated access
        //    options.AddPolicy("AuthenticatedUser", policy =>
        //        policy.RequireAuthenticatedUser());
        //});
    }
}