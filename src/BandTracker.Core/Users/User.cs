namespace BandTracker.Core.Bands;
public class User
{
    private readonly List<Band> _followedBands = new();

    public Guid UserId { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;

    public IReadOnlyList<Band> FollowedBands => _followedBands;

    public Result Follow(Band band)
    {
        if (_followedBands.Contains(band))
        {
            return Result.Fail("User is already following this band");
        }

        _followedBands.Add(band);

        return Result.Ok();
    }

    public Result Unfollow(Band band)
    {
        if (!_followedBands.Contains(band))
        {
            return Result.Fail("User isn't following this band");
        }

        _followedBands.Remove(band);

        return Result.Ok();
    }
}