using Backend_Test_DynamoDB.DTO.GameProgressions;

namespace Backend_Test_DynamoDB.Services.GameProgressions
{
    public interface IGameProgressionsService
    {
        public Task<GetPlayerMetadataResponse> GetMetadata(string playerId, string sessionId);

        public Task<GetPlayerGameDataResponse> GetPlayerGameData(string playerId, string sessionId);

        public Task<bool> UnsertGameProgression(UnsertPlayerGameDataRequest request);
    }
}
