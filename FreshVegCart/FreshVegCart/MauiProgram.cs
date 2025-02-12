using CommunityToolkit.Maui;
using FreshVegCart.Apis;
using FreshVegCart.Services;
using FreshVegCart.Shared.Services;
using Microsoft.Extensions.Logging;

namespace FreshVegCart;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var services = builder.Services;

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Add device-specific services used by the FreshVegCart.Shared project
        services.AddSingleton<IFormFactor, FormFactor>();

        services.AddMauiBlazorWebView();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        services.ConfigureRefit();

        return builder.Build();
    }
}
