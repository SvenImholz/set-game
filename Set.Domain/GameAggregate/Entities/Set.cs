using Set.Domain.Common.Models;
using Set.Domain.GameAggregate.ValueObjects;

namespace Set.Domain.GameAggregate.Entities;

public sealed class Set : Entity<SetId>
{

    public Set(SetId setId) : base(setId) {}
}