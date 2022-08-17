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
}