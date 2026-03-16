using Backend_Test_DynamoDB.DTO.GameProgressions;
using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories;

namespace Backend_Test_DynamoDB.Services.GameProgressions
{
    public class GameProgresssionService : IGameProgressionsService
    {
        private IPlayerRepository _playerRepo;

        public GameProgresssionService(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<GetPlayerMetadataResponse> GetMetadata(string playerId, string sessionId)
        {
            GetPlayerMetadataResponse response = new GetPlayerMetadataResponse();

            PlayerData playerData = await _playerRepo.GetAsync(playerId);

            if (playerData == null)
            {
                response.Success = false;
                response.MetadataResult = EMetadataResult.NoProfile;

                return response;
            }

            return response;
        }

        public Task<GetPlayerGameDataResponse> GetPlayerGameData(string playerId, string sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnsertGameProgression(UnsertPlayerGameDataRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
