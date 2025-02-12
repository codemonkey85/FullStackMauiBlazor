namespace FreshVegCart.Apis;

public static class Registration
{
    public static IServiceCollection ConfigureRefit(this IServiceCollection services)
    {
        var baseApiUrl = "https://localhost:7025";

        return services;
    }
}
