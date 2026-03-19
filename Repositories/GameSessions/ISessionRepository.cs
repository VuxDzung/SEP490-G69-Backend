using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Repositories.GameSessions
{
    public interface ISessionRepository
    {
        Task<PlayerGameSession> GetAsync(string id);
        Task<bool> SaveAsync(PlayerGameSession entity);
        Task<List<PlayerGameSession>> GetAllAsync(string playerId);
        Task<bool> DeleteAsync(PlayerGameSession entity);
    }
}
