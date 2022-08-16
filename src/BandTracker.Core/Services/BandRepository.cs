namespace BandTracker.Core.Services;
public class BandRepository : IBandRepository
{
    private readonly List<Band> _bands;
    private readonly List<Release> _releases;

    public BandRepository()
    {
        _bands = new FakeBandGenerator().Generate(30);
        _releases = _bands.SelectMany(a => a.Releases).ToList();
    }

    public IReadOnlyList<Band> GetAll()
    {
        return _bands;
    }

    public Result<Band> FindBandById(Guid bandId)
    {
        var band = _bands.FirstOrDefault(a => a.BandId == bandId);

        if (band is null)
        {
            return Result.Fail("Band with this ID was not found");
        }

        return band;
    }

    public Result<Release> FindReleaseById(Guid releaseId)
    {
        var release = _releases.FirstOrDefault(a => a.ReleaseId == releaseId);

        if (release is null)
        {
            return Result.Fail("Release with this ID was not found");
        }

        return release;
    }
}
