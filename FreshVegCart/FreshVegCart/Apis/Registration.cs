using Refit;

namespace FreshVegCart.Apis;

public static class Registration
{
    public static IServiceCollection ConfigureRefit(this IServiceCollection services)
    {
        services
            .AddRefitClient<IAuthApi>()
            .ConfigureHttpClient(SetHttpClient);

        services
            .AddRefitClient<IProductApi>()
            .ConfigureHttpClient(SetHttpClient);

        services
            .AddRefitClient<IOrderApi>(GetRefitSettings)
            .ConfigureHttpClient(SetHttpClient);

        services
            .AddRefitClient<IUserApi>(GetRefitSettings)
            .ConfigureHttpClient(SetHttpClient);

        return services;

        static void SetHttpClient(HttpClient httpClient)
        {
            const string baseApiUrl = "https://q12tz1jn-7025.use.devtunnels.ms/";
            httpClient.BaseAddress = new Uri(baseApiUrl);
        }

        static RefitSettings GetRefitSettings(IServiceProvider sp)
        {
            var settings = new RefitSettings
            {
                AuthorizationHeaderValueGetter = (_, _) =>
                Task.FromResult("TOKEN")
            };

            return settings;
        }
    }
}
