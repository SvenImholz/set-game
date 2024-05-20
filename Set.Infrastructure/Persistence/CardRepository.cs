using Set.Application.Common.Interfaces.Persistence;
using Set.Domain.Deck.Entities;

namespace Set.Infrastructure.Persistence;

public class CardRepository : ICardRepository
{

    public IEnumerable<Card> GetCards() => throw new NotImplementedException();
    public Card? GetCardById(Guid id) => throw new NotImplementedException();
}