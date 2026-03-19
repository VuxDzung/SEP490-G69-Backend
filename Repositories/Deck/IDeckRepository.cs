using Backend_Test_DynamoDB.Models.Cards;

namespace Backend_Test_DynamoDB.Repositories.Deck
{
    public interface IDeckRepository
    {
        public Task<SessionDeck> GetDeckById(string playerId);
        public Task<bool> DeleteDeckById(string playerId);
        public Task<bool> SaveAsync(SessionDeck deck);
    }
}
