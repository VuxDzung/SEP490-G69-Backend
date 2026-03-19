using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Backend_Test_DynamoDB.Models.Cards;

namespace Backend_Test_DynamoDB.Repositories.Cards
{
    public class CardRepository : ICardRepository
    {
        private readonly DynamoDBContext _context;

        public CardRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteAsync(SessionCardData entity)
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

        public async Task<List<SessionCardData>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<SessionCardData> search = _context.ScanAsync<SessionCardData>(conditions);

                List<SessionCardData> cards = await search.GetRemainingAsync();

                return cards;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<List<SessionCardData>> GetAllBySessionId(string sessionId)
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<SessionCardData> search = _context.ScanAsync<SessionCardData>(conditions);

                List<SessionCardData> cards = await search.GetRemainingAsync();

                return cards;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<SessionCardData> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<SessionCardData>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(SessionCardData entity)
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
