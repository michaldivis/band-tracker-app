namespace BandTracker.Core.Bands;

public interface IBandRepository
{
    Task EnsureLoadedAsync();
    void EnsureLoaded();

    IReadOnlyList<Band> GetAll();
    IReadOnlyList<string> GetGenres();
    IReadOnlyList<FullRelease> GetRecentReleases(int amount);
    IReadOnlyList<FullShow> GetUpcomingShows(int amount);
}