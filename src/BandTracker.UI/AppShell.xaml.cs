using BandTracker.UI.Views;

namespace BandTracker.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(BandView), typeof(BandView));
    }
}
