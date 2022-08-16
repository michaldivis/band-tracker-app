namespace BandTracker.Core.Users;

public interface IUserRepository
{
    Result<User> FindUserById(Guid userId);
    IReadOnlyList<User> GetAll();
}