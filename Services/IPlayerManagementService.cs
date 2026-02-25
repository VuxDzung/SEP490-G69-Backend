using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Services
{
    public interface IPlayerManagementService
    {
        Task<bool> DeletePlayer(string playerId);
        Task<List<PlayerData>> GetAllPlayers();
    }
}
