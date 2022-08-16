namespace BandTracker.UI.Setup;
internal static class ServicesSetup
{
    public static void Configure(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IBandRepository, BandRepository>();
    }
}
