namespace BandTracker.Core.Bands;
public class BandRepository : IBandRepository
{
    private readonly List<Band> _bands;
    private readonly List<Release> _releases;
    private readonly List<Show> _shows;

    public BandRepository()
    {
        _bands = new FakeBandGenerator().Generate(30);
        _releases = _bands.SelectMany(a => a.Releases).ToList();
        _shows = _bands.SelectMany(a => a.Shows).ToList();
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

    public IReadOnlyList<Release> GetRecentReleases(int amount)
    {
        return _releases
            .OrderByDescending(a => a.ReleaseDate)
            .Take(amount)
            .ToList();
    }

    public IReadOnlyList<Show> GetUpcomingShows(int amount)
    {
        return _shows
            .OrderBy(a => a.Date)
            .Take(amount)
            .ToList();
    }
}
