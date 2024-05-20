using Set.Domain.Common.Models;
using Set.Domain.Game.ValueObjects;

namespace Set.Domain.Game.Entities;

public sealed class Set : Entity<SetId>
{

    public Set(SetId playerId) : base(playerId) {}
}