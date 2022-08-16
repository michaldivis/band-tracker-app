namespace BandTracker.Core.Bands;

public class Show
{
    public Guid ShowId { get; init; }
    public Band Band { get; set; } = null!;

    public DateTime Date { get; init; }
    public string Location { get; init; } = null!;

    public override string ToString()
    {
        return $"{Location} - {Date}";
    }
}
