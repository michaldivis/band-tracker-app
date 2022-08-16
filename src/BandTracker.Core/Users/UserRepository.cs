namespace BandTracker.Core.Users;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new FakeUserGenerator().Generate(30);
    }

    public IReadOnlyList<User> GetAll()
    {
        return _users;
    }

    public Result<User> FindUserById(Guid userId)
    {
        var user = _users.FirstOrDefault(a => a.UserId == userId);

        if (user is null)
        {
            return Result.Fail("User with this ID was not found");
        }

        return user;
    }
}