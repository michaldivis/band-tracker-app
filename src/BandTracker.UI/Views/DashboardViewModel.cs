using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;

public class DashboardViewModel : ObservableObject
{
    public ObservableCollection<Release> RecentReleases { get; }

    public DashboardViewModel()
    {
        var bandsRepository = DI.Resolve<IBandRepository>();
        var recentReleases = bandsRepository.GetRecentReleases(5);
        RecentReleases = new(recentReleases);
    }
}