using Microsoft.Extensions.Configuration;
using SpotifyBandScraper;

var configration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var spotifyClientId = configration["Spotify:ClientId"];
var spotifyClientSecret = configration["Spotify:ClientSecret"];

var scraper = new Scraper();

var scrapedJson = await scraper.ScrapeBands(spotifyClientId, spotifyClientSecret);

Console.WriteLine(scrapedJson);