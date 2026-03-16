using Backend_Test_DynamoDB.Models.Cards;

namespace Backend_Test_DynamoDB.Repositories.Cards
{
    public interface ICardRepository
    {
        Task<SessionCardData> GetAsync(string playerId);
        Task SaveAsync(SessionCardData player);
        Task<List<SessionCardData>> GetAllAsync();
        Task DeleteAsync(SessionCardData player);
    }
}
