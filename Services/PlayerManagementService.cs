using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories;

namespace Backend_Test_DynamoDB.Services
{
    public class PlayerManagementService : IPlayerManagementService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerManagementService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> DeletePlayer(string playerId)
        {
            try
            {
                PlayerData player = await _playerRepository.GetAsync(playerId);
                if (player == null)
                {
                    return false;
                }
                await _playerRepository.DeleteAsync(player);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<PlayerData>> GetAllPlayers()
        {
            return await _playerRepository.GetAllAsync();
        }
    }
}
