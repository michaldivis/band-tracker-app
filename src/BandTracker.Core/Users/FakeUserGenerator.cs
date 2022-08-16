using Bogus;

namespace BandTracker.Core.Users;

public class FakeUserGenerator
{
    private readonly Faker<User> _faker;

	public FakeUserGenerator()
	{
		_faker = new Faker<User>()
			.RuleFor(a => a.UserId, Guid.NewGuid())
			.RuleFor(a => a.FirstName, f => f.Person.FirstName)
			.RuleFor(a => a.LastName, f => f.Person.LastName);
    }

	public List<User> Generate(int amount)
	{
		return _faker.Generate(amount);
	}
}
