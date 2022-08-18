namespace BandTracker.UI.Views;

[QueryProperty(nameof(ArtistName), nameof(ArtistName))]
[QueryProperty(nameof(Release), nameof(Release))]
public partial class ReleaseViewModel : VmBase
{
    [ObservableProperty]
    private string? _artistName;

    [ObservableProperty]
    private Release? _release;
}