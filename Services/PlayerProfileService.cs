using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories;
using System.Xml.Linq;

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
                Console.WriteLine($"Update player name of {playerId} to {playerData.PlayerName} successfully!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<string> GetPlayerName(string playerId)
        {
            try
            {
                PlayerData playerData = await _repository.GetAsync(playerId);

                if (playerData == null)
                {
                    return "";
                }

                return playerData.PlayerName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
