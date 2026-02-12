using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Repositories
{
    public interface IPlayerRepository
    {
        Task<PlayerData?> GetAsync(string playerId);
        Task SaveAsync(PlayerData player);
    }
}
