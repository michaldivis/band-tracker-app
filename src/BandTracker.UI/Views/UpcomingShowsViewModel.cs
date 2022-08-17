using System.Collections.ObjectModel;

namespace BandTracker.UI.Views;

public partial class UpcomingShowsViewModel : VmBase
{
    public ObservableCollection<FullShow> UpcomingShows { get; }

    public UpcomingShowsViewModel(IBandRepository bandRepository)
    {
        var upcomingShows = bandRepository.GetUpcomingShows(100);
        UpcomingShows = new(upcomingShows);
    }
}