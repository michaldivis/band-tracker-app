using BandTracker.UI.Services;
using BandTracker.UI.Views;

namespace BandTracker.UI.Setup;
internal static class ServicesSetup
{
    public static void Configure(MauiAppBuilder builder)
    {
        builder.Services.AddHttpClient();
        builder.Services.AddSingleton<ImageColorReader>();        

        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IBandRepository, BandRepository>();

        builder.Services.AddSingleton<IHtmlAssetProvider, PlatformHtmlAssetProvider>();
        builder.Services.AddSingleton<IHtmlUtilityService, HtmlUtilityService>();        

        builder.Services.AddTransient<BandsViewModel>();
        builder.Services.AddTransient<BandsView>();
        builder.Services.AddTransient<BandViewModel>();
        builder.Services.AddTransient<BandView>();
        builder.Services.AddTransient<ReleaseViewModel>();
        builder.Services.AddTransient<ReleaseView>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<DashboardView>();
        builder.Services.AddTransient<RecentReleasesViewModel>();
        builder.Services.AddTransient<RecentReleasesView>();
        builder.Services.AddTransient<UpcomingShowsViewModel>();
        builder.Services.AddTransient<UpcomingShowsView>();
    }
}
