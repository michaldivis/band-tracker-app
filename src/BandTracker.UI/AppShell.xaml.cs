﻿using BandTracker.UI.Views;

namespace BandTracker.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(BandView), typeof(BandView));
        Routing.RegisterRoute(nameof(ReleaseView), typeof(ReleaseView));
        Routing.RegisterRoute(nameof(RecentReleasesView), typeof(RecentReleasesView));
        Routing.RegisterRoute(nameof(UpcomingShowsView), typeof(UpcomingShowsView));
    }
}
