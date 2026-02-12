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

        public async Task<PlayerData?> GetAsync(string playerId)
        {
            return await _context.LoadAsync<PlayerData>(playerId);
        }

        public async Task SaveAsync(PlayerData player)
        {
            await _context.SaveAsync(player);
        }
    }
}
