namespace BandTracker.UI.Views;

[QueryProperty("Release", "ReleaseToOpen")]
public partial class ReleaseViewModel : VmBase
{
    [ObservableProperty]
    private Release? _release;
}