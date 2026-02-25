using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories;

namespace Backend_Test_DynamoDB.Services
{
    public class PlayerProfileService : IPlayerProfileService
    {
        private IPlayerRepository _repository;

        public PlayerProfileService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> TryUpdatePlayerName(string playerId, string name)
        {
            try
            {
                PlayerData playerData = await _repository.GetAsync(playerId);
                if (playerData == null)
                {
                    return false;
                }

                playerData.PlayerName = name;
                await _repository.SaveAsync(playerData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
