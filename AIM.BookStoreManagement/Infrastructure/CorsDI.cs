namespace AIM.BookStoreManagement.Infrastructure;

public static class CorsDI
{
    public static void AddCorsPolicy(this IServiceCollection services)
    {
        // Add CORS (important for Blazor app on a different domain)
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("https://localhost:7119") // Your Blazor client URL
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }
}