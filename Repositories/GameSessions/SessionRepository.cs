using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Repositories.GameSessions
{
    public class SessionRepository
    {
        private readonly DynamoDBContext _context;

        public SessionRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteAsync(PlayerGameSession entity)
        {
            try
            {
                await _context.DeleteAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<PlayerGameSession>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<PlayerGameSession> search = _context.ScanAsync<PlayerGameSession>(conditions);

                List<PlayerGameSession> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<PlayerGameSession> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<PlayerGameSession>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(PlayerGameSession entity)
        {
            try
            {
                await _context.SaveAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
