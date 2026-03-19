using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Characters;
using Amazon.DynamoDBv2.DocumentModel;

namespace Backend_Test_DynamoDB.Repositories.Characters
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DynamoDBContext _context;

        public CharacterRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteAsync(SessionCharacterData entity)
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

        public async Task<List<SessionCharacterData>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<SessionCharacterData> search = _context.ScanAsync<SessionCharacterData>(conditions);

                List<SessionCharacterData> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<SessionCharacterData>();
            }
        }

        public async Task<SessionCharacterData> GetAsync(string entityId)
        {
            try
            {
                return await _context.LoadAsync<SessionCharacterData>(entityId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(SessionCharacterData entity)
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
