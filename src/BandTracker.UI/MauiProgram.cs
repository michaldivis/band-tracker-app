using BandTracker.UI.Setup;
using CommunityToolkit.Maui;
using DevExpress.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace BandTracker.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseDevExpress()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts
                    .AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                    .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                    .AddFont("Rubik-Light.ttf", "RubikLight")
                    .AddFont("Rubik-Regular.ttf", "RubikRegular")
                    .AddFont("Rubik-SemiBold.ttf", "RubikSemiBold")
                    .AddFont("Rubik-Bold.ttf", "RubikBold")
                    .AddFont("fa-solid-900.ttf", "FaSolid");
            });

        ServicesSetup.Configure(builder);

        var app = builder.Build();

        DI.SetProvider(app.Services);

        return app;
    }
}
