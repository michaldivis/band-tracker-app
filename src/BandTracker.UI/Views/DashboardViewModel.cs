using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;

public partial class DashboardViewModel : VmBase
{
    public ObservableCollection<FullRelease> RecentReleases { get; }
    public ObservableCollection<FullShow> UpcomingShows { get; }

    public DashboardViewModel()
    {
        var bandsRepository = DI.Resolve<IBandRepository>();

        var recentReleases = bandsRepository.GetRecentReleases(5);
        RecentReleases = new(recentReleases);

        var upcomingShows = bandsRepository.GetUpcomingShows(5);
        UpcomingShows = new(upcomingShows);
    }

    [RelayCommand]
    private void GoToRecentReleases()
    {

    }

    [RelayCommand]
    private void GoToUpcomingShows()
    {

    }
}
