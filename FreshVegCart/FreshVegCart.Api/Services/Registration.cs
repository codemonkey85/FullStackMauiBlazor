namespace FreshVegCart.Api.Services;

public static class Registration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddScoped<AuthService>()
            .AddScoped<ProductService>()
            .AddScoped<OrderService>()
            .AddScoped<UserService>();
}
