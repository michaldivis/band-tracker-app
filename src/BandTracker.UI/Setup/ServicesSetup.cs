using BandTracker.UI.Views;

namespace BandTracker.UI.Setup;
internal static class ServicesSetup
{
    public static void Configure(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IBandRepository, BandRepository>();

        builder.Services.AddTransient<BandsViewModel>();
        builder.Services.AddTransient<BandsView>();
        builder.Services.AddTransient<BandViewModel>();
        builder.Services.AddTransient<BandView>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<DashboardView>();
        builder.Services.AddTransient<RecentReleasesViewModel>();
        builder.Services.AddTransient<RecentReleasesView>();
        builder.Services.AddTransient<UpcomingShowsViewModel>();
        builder.Services.AddTransient<UpcomingShowsView>();
    }
}
