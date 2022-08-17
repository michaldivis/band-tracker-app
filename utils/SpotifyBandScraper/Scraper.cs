using BandTracker.Core.Bands;
using SpotifyAPI.Web;
using System.Text.Json;

namespace SpotifyBandScraper;

public class Scraper
{
    private readonly List<string> _artistIds = new()
    {
        "0z4ODfFM8PGE0A9r0tZ75J", //Vildhjarta,
        "2n2RSaZqBuUUukhbLlpnE6", //Sleep Token,
        "6ncfp4E8TXGnp6nYwBUwwj", //Uneven Structure
        "7nKz8GVqHk0bUGmBm6wm3E", //HLB
        "65C6Unk7nhg2aCnVuAPMo8", //AAL
        "6XP64Chkji2mFpszEudUkq", //Frostbitt
        "5fyb3eB9tytxWDlNxPXIDV", //Michal Divis
        "0BIjauWeJCyBiGmo98WrZR", //Yatsu
        "4dpARuHxo51G3z768sgnrY", //Adele
        "7KoDzIRehLGK5dmARH0mB8", //Revaira
        "6YRr0btzGqfQ5K7r23qjEM", //Allt
        "7o6cOczXTB8ioTAAJTbESf", //Jinjer
        "3qyg72RGnGdF521zMU02u9", //Northlane
        "4MzJMcHQBl9SIYSjwWn8QW", //Spiritbox
        "38G3QPFHq8xkq7BmJXMM13", //Greylotus
        "2dE5audbkV3o5cKxvM7lBD", //Thornhill
        "0sCAofrHFyDFPxXA0B7a86", //Anup Sastry
        "23ytwhG1pzX6DIVWRWvW1r", //Tesseract
        "71IBhhBhtPLZ8OyVuXOw77", //Monuments
        "2KW8rQ2SlUQNNdD20BLzQR", //DSME
        "6d24kC5fxHFOSEAmjQPPhc", //Periphery
    };

    public async Task<string> ScrapeBands(string spotifyClientId, string spotifyClientSecret)
    {
        var config = SpotifyClientConfig.CreateDefault();
        var request = new ClientCredentialsRequest(spotifyClientId, spotifyClientSecret);
        var response = await new OAuthClient(config).RequestToken(request);

        var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

        var bands = new List<Band>();

        foreach (var artistId in _artistIds)
        {
            try
            {
                var releases = new List<Release>();
                var artist = await spotify.Artists.Get(artistId);
                var albums = await spotify.Artists.GetAlbums(artistId);

                await foreach (var album in spotify.Paginate(albums))
                {
                    var tracks = new List<Track>();
                    var songs = await spotify.Albums.GetTracks(album.Id);

                    await foreach (var song in spotify.Paginate(songs))
                    {
                        tracks.Add(new Track
                        {
                            TrackId = song.Id,
                            Name = song.Name,
                            TrackNumber = song.TrackNumber
                        });
                    }

                    releases.Add(new Release
                    {
                        //Author = band,
                        AlbumId = album.Id,
                        Name = album.Name,
                        ArtImageUrl = album.Images.MaxBy(a => a.Height).Url,
                        ReleaseDate = DateTime.Parse(album.ReleaseDate),
                        ReleaseType = album.AlbumType,
                        Tracks = tracks
                    });
                }

                bands.Add(new Band
                {
                    ArtistId = artist.Id,
                    Name = artist.Name,
                    Followers = artist.Followers.Total,
                    AvatarImageUrl = artist.Images.MaxBy(a => a.Height).Url,
                    Genres = artist.Genres,
                    Releases = releases
                });

                Console.WriteLine($"Imported {artist.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error for artist ID {artistId}: {ex}");
            }
        }

        var serialized = JsonSerializer.Serialize(bands, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        return serialized;
    }
}