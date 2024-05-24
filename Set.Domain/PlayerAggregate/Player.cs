using Set.Domain.Common.Models;
using Set.Domain.GameAggregate.ValueObjects;
using Set.Domain.PlayerAggregate.ValueObjects;

namespace Set.Domain.PlayerAggregate;

public class Player : AggregateRoot<PlayerId>
{
    Player(PlayerId playerId, string firstName, string lastName,
        string email,
        string password) : base(playerId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public static Player Create(
        string firstName,
        string lastName,
        string email,
        string password) =>
        new(PlayerId.CreateUnique(), firstName, lastName, email, password);
        
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    readonly IReadOnlyList<GameId> _games = [];
}