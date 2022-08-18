using BandTracker.Core.Bands;
using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;

public partial class DashboardViewModel : VmBase
{
    public ObservableCollection<FullRelease> RecentReleases { get; }
    public ObservableCollection<FullShow> UpcomingShows { get; }

    public DashboardViewModel(IBandRepository bandRepository)
    {
        var recentReleases = bandRepository.GetRecentReleases(5);
        RecentReleases = new(recentReleases);

        var upcomingShows = bandRepository.GetUpcomingShows(5);
        UpcomingShows = new(upcomingShows);
    }

    [RelayCommand]
    private async Task GoToRecentReleasesAsync()
    {
        await Shell.Current.GoToAsync(nameof(RecentReleasesView), true);
    }

    [RelayCommand]
    private async Task GoToUpcomingShowsAsync()
    {
        await Shell.Current.GoToAsync(nameof(UpcomingShowsView), true);
    }

    [RelayCommand]
    private async Task GoToReleaseAsync(FullRelease release)
    {
        await Shell.Current.GoToAsync(nameof(ReleaseView), true, new Dictionary<string, object>
        {
            { "ReleaseToOpen", release }
        });
    }
}
