namespace BandTracker.Core.Bands;

public interface IBandRepository
{
    IReadOnlyList<Band> GetAll();
    IReadOnlyList<FullRelease> GetRecentReleases(int amount);
    IReadOnlyList<FullShow> GetUpcomingShows(int amount);
}