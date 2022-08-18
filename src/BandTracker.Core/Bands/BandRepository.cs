using Bogus;
using System.Text.Json;

namespace BandTracker.Core.Bands;
public class BandRepository : IBandRepository
{
    private readonly Faker<Show> _showFaker;

    private readonly List<Band> _bands = new();
    private readonly List<FullRelease> _recentReleases = new();
    private readonly List<FullShow> _upcomingShows = new();
    private readonly List<string> _genres = new();

    private bool _loaded;

    public BandRepository()
    {
        _showFaker = new Faker<Show>()
            .RuleFor(a => a.ShowId, Guid.NewGuid())
            .RuleFor(a => a.Location, f => $"{f.Address.City()}, {f.Address.Country()}")
            .RuleFor(a => a.Date, f => f.Date.Future());
    }

    public async Task EnsureLoadedAsync()
    {
        if (_loaded)
        {
            return;
        }

        await Task.Run(EnsureLoaded).ConfigureAwait(false);
    }

    public void EnsureLoaded()
    {
        if (_loaded)
        {
            return;
        }

        var bands = JsonSerializer.Deserialize<List<Band>>(RawBands.Json);

        var random = new Random();

        foreach (var band in bands)
        {
            var shows = _showFaker
                .Generate(random.Next(5))
                .OrderBy(a => a.Date);
            band.Shows.AddRange(shows);
        }

        _bands.AddRange(bands);

        _recentReleases.AddRange(_bands
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
            .OrderByDescending(a => a.ReleaseDate));

        _upcomingShows.AddRange(_bands
            .SelectMany(a => a.Shows
                .Select(x => new FullShow
                {
                    ArtistName = a.Name,
                    ArtistAvatarImageUrl = a.AvatarImageUrl,
                    ShowId = x.ShowId,
                    Date = x.Date,
                    Location = x.Location
                }))
            .OrderBy(a => a.Date));

        _genres.AddRange(_bands.SelectMany(a => a.Genres).Distinct());

        _loaded = true;
    }

    public IReadOnlyList<Band> GetAll()
    {
        return _bands;
    }

    public IReadOnlyList<string> GetGenres()
    {
        return _genres;
    }

    public IReadOnlyList<FullRelease> GetRecentReleases(int amount)
    {
        return _recentReleases
            .Take(amount)
            .ToList();
    }

    public IReadOnlyList<FullShow> GetUpcomingShows(int amount)
    {
        return _upcomingShows
            .Take(amount)
            .ToList();
    }
}
