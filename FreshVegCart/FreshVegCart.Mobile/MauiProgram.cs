using CommunityToolkit.Maui;
using FreshVegCart.Mobile.Apis;
using Microsoft.Extensions.Logging;

namespace FreshVegCart.Mobile;

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

        services.AddMauiBlazorWebView();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        services.ConfigureRefit();

        return builder.Build();
    }
}
