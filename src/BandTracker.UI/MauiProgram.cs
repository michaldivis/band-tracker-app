using Android.Views;
using BandTracker.UI.Setup;
using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Maui.LifecycleEvents;
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
            })
            .ConfigureLifecycleEvents(ConfigureLifecycle);

        ServicesSetup.Configure(builder);

        var app = builder.Build();

        DI.SetProvider(app.Services);

        return app;
    }

    private static void ConfigureLifecycle(ILifecycleBuilder lifecycleBuilder)
    {
#if ANDROID
        lifecycleBuilder
            .AddAndroid(android => android
            .OnCreate((activity, bundle) => MakeAppFulscreen(activity)));

        static void MakeAppFulscreen(Android.App.Activity activity)
        {
            if(activity?.Window is null)
            {
                return;
            }

            //set app to fullscreen
            activity.Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
            activity.Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

            //hide bottom buttons
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.Fullscreen |
                                                                          SystemUiFlags.HideNavigation |
                                                                          SystemUiFlags.Immersive |
                                                                          SystemUiFlags.ImmersiveSticky |
                                                                          SystemUiFlags.LayoutHideNavigation |
                                                                          SystemUiFlags.LayoutStable |
                                                                          SystemUiFlags.LowProfile);            
        }
#endif
    }
}
