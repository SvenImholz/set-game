using SetGame.Domain.DeckAggregate.Entities;

namespace SetGame.Application.Common.Interfaces.Persistence;

public interface ICardRepository
{
    IEnumerable<Card> GetCards();
    Card? GetCardById(Guid id);
}