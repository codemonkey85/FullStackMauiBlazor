using Refit;

namespace FreshVegCart.Apis;

public static class Registration
{
    public static IServiceCollection ConfigureRefit(this IServiceCollection services)
    {
        services
            .AddRefitClient<IProductApi>()
            .ConfigureHttpClient(SetHttpClient);

        return services;

        static void SetHttpClient(HttpClient httpClient)
        {
            const string baseApiUrl = "https://localhost:7025";
            httpClient.BaseAddress = new Uri(baseApiUrl);
        }
    }
}
