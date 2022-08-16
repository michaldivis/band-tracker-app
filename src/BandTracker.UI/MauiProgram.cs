using BandTracker.UI.Setup;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace BandTracker.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Rubik-Light.ttf", "RubikLight");
                fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                fonts.AddFont("Rubik-SemiBold.ttf", "RubikSemiBold");
                fonts.AddFont("Rubik-Bold.ttf", "RubikBold");
                fonts.AddFont("fa-solid-900.ttf", "FaSolid");
            });

        ServicesSetup.Configure(builder);

        var app = builder.Build();

        DI.SetProvider(app.Services);

        return app;
    }
}
