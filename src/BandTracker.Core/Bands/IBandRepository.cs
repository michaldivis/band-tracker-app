namespace BandTracker.Core.Bands;

public interface IBandRepository
{
    Result<Band> FindBandById(Guid bandId);
    Result<Release> FindReleaseById(Guid releaseId);
    IReadOnlyList<Band> GetAll();
    IReadOnlyList<Release> GetRecentReleases(int amount);
}