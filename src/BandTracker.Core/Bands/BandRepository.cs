using Bogus;
using System.Text.Json;

namespace BandTracker.Core.Bands;
public class BandRepository : IBandRepository
{
    private readonly Faker<Show> _showFaker;

    private readonly List<Band> _bands;

    public BandRepository()
    {
        _showFaker = new Faker<Show>()
            .RuleFor(a => a.ShowId, Guid.NewGuid())
            .RuleFor(a => a.Location, f => $"{f.Address.City()}, {f.Address.Country()}")
            .RuleFor(a => a.Date, f => f.Date.Future());

        var bands = JsonSerializer.Deserialize<List<Band>>(RawBands.Json);

        var random = new Random();
        foreach (var band in bands)
        {
            var shows = _showFaker.Generate(random.Next(5));
            band.Shows.AddRange(shows);
        }

        _bands = bands;     
    }

    public IReadOnlyList<Band> GetAll()
    {
        return _bands;
    }

    public IReadOnlyList<FullRelease> GetRecentReleases(int amount)
    {
        return _bands
            .SelectMany(a => a.Releases
                .Select(x => new FullRelease
                {
                    ArtistName = a.Name,
                    ArtistAvatarImageUrl = a.AvatarImageUrl,
                    AlbumId = x.AlbumId,
                    ArtImageUrl = x.ArtImageUrl,
                    Name = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    ReleaseType = x.ReleaseType,
                    Tracks = x.Tracks
                }))
            .OrderByDescending(a => a.ReleaseDate)
            .Take(amount)
            .ToList();
    }

    public IReadOnlyList<FullShow> GetUpcomingShows(int amount)
    {
        return _bands
            .SelectMany(a => a.Shows
                .Select(x => new FullShow
                {
                    ArtistName = a.Name,
                    ArtistAvatarImageUrl = a.AvatarImageUrl,
                    ShowId = x.ShowId,
                    Date = x.Date,
                    Location = x.Location
                }))
            .OrderBy(a => a.Date)
            .Take(amount)
            .ToList();
    }
}
