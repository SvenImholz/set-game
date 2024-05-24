using Set.Domain.DeckAggregate.Entities;

namespace Set.Application.Common.Interfaces.Persistence;

public interface ICardRepository
{
    IEnumerable<Card> GetCards();
    Card? GetCardById(Guid id);
}