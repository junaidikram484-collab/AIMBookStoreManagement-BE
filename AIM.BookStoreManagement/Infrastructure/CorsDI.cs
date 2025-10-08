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
                policy.AllowAnyOrigin() // Your Blazor client URL
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}