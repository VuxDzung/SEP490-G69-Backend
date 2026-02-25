using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DynamoDBContext _context;

        public PlayerRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<PlayerData> GetAsync(string playerId)
        {
            return await _context.LoadAsync<PlayerData>(playerId);
        }

        public async Task SaveAsync(PlayerData player)
        {
            await _context.SaveAsync(player);
        }

        public async Task<List<PlayerData>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();

            var search = _context.ScanAsync<PlayerData>(conditions);

            var result = await search.GetRemainingAsync();

            return result;
        }

        public async Task DeleteAsync(PlayerData playerData)
        {
            // Delete player.
            await _context.DeleteAsync(playerData);
        }
    }
}
