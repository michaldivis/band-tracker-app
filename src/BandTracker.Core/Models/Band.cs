namespace BandTracker.Core.Models;
public record Band(string Name, string AvatarImageUrl, string BackgroundImageUrl, IEnumerable<Release> Releases);
