using SetGame.Domain.Common.Models;
using SetGame.Domain.GameAggregate.ValueObjects;
using SetGame.Domain.PlayerAggregate.ValueObjects;

namespace SetGame.Domain.PlayerAggregate;

public class Player : AggregateRoot<PlayerId>
{

    private readonly IReadOnlyList<GameId> _games = [];
    private Player(
        PlayerId id,
        string firstName,
        string lastName,
        string email,
        string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public static Player Create(
        string firstName,
        string lastName,
        string email,
        string password) =>
        new(
        PlayerId.CreateUnique(),
        firstName,
        lastName,
        email,
        password);
}