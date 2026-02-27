namespace Backend_Test_DynamoDB.Services
{
    public interface IPlayerProfileService
    {
        public Task<bool> TryUpdatePlayerName(string playerId, string name);
        Task<string> GetPlayerName(string playerId);
    }
}