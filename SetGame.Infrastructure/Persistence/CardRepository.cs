using SetGame.Application.Common.Interfaces.Persistence;
using SetGame.Domain.DeckAggregate.Entities;

namespace SetGame.Infrastructure.Persistence;

public class CardRepository : ICardRepository
{
    public IEnumerable<Card> GetCards() => throw new NotImplementedException();
    public Card? GetCardById(Guid id) => throw new NotImplementedException();
}