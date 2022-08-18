using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;

public partial class RecentReleasesViewModel : VmBase
{
    public ObservableCollection<FullRelease> RecentReleases { get; }

    public RecentReleasesViewModel(IBandRepository bandRepository)
    {
        var recentReleases = bandRepository.GetRecentReleases(100);
        RecentReleases = new(recentReleases);
    }

    [RelayCommand]
    private async Task GoToReleaseAsync(FullRelease release)
    {
        await Shell.Current.GoToAsync(nameof(ReleaseView), true, new Dictionary<string, object>
        {
            { nameof(ReleaseViewModel.ArtistName), release.ArtistName },
            { nameof(ReleaseViewModel.Release), release.ToBasicRelease() }
        });
    }
}