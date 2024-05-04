using Set.Domain.Game.ValueObjects;
using Set.Domain.Models;

namespace Set.Domain.Game.Entities;

public sealed class Set : Entity<SetId>
{

    public Set(SetId id) : base(id) {}
}