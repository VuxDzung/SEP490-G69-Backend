using Backend_Test_DynamoDB.Models.Cards;

namespace Backend_Test_DynamoDB.Repositories.Cards
{
    public interface ICardRepository
    {
        Task<SessionCardData> GetAsync(string playerId);
        Task<bool> SaveAsync(SessionCardData player);
        Task<List<SessionCardData>> GetAllAsync();
        Task<List<SessionCardData>> GetAllBySessionId(string sessionId);
        Task<bool> DeleteAsync(SessionCardData player);
    }
}
