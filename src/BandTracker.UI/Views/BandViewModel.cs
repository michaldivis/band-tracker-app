namespace BandTracker.UI.Views;

[QueryProperty("Band", "BandToOpen")]
public partial class BandViewModel : VmBase
{
    [ObservableProperty]
    private Band? _band;
}