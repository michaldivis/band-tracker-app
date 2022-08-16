namespace BandTracker.Core.Services;

public interface IBandRepository
{
    Result<Band> FindBandById(Guid bandId);
    Result<Release> FindReleaseById(Guid releaseId);
    IReadOnlyList<Band> GetAll();
}