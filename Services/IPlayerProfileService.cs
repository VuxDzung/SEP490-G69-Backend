namespace Backend_Test_DynamoDB.Services
{
    public interface IPlayerProfileService
    {
        public Task<bool> TryUpdatePlayerName(string playerId, string name);
    }
}