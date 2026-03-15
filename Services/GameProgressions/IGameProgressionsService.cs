using Backend_Test_DynamoDB.DTO.GameProgressions;

namespace Backend_Test_DynamoDB.Services.GameProgressions
{
    public interface IGameProgressionsService
    {
        public GetPlayerMetadataResponse GetMetadata(string playerId, string sessionId);

        public GetPlayerGameDataResponse GetPlayerProgression(string playerId, string sessionId);

        public bool UnsertGameProgression(UnsertPlayerGameDataRequest request);
    }
}
