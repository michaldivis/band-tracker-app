namespace BandTracker.Core.Models;

public record Release(string Name, IEnumerable<Track> Tracks);
