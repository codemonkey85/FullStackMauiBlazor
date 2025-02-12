namespace FreshVegCart.Api.Services;

public static class Registration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddTransient<AuthService>()
            .AddTransient<ProductService>()
            .AddTransient<OrderService>()
            .AddTransient<UserService>()
            .AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
}
