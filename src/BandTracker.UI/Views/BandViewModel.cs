namespace BandTracker.UI.Views;

[QueryProperty("Band", "BandToOpen")]
public partial class BandViewModel : VmBase
{
    [ObservableProperty]
    private Band? _band;

    [RelayCommand]
    private async Task GoToReleaseAsync(Release release)
    {
        await Shell.Current.GoToAsync(nameof(ReleaseView), true, new Dictionary<string, object>
        {
            { "ReleaseToOpen", release }
        });
    }
}