using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Repositories.GameSessions
{
    public interface ISessionRepository
    {
        Task<PlayerGameSession> GetAsync(string playerId);
        Task SaveAsync(PlayerGameSession player);
        Task<List<PlayerGameSession>> GetAllAsync();
        Task DeleteAsync(PlayerGameSession player);
    }
}
