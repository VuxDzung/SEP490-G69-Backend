using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Tournaments;
using Amazon.DynamoDBv2.DocumentModel;

namespace Backend_Test_DynamoDB.Repositories.Tournaments
{
    public class TournamentsRepository : ITournamentRepository
    {
        private readonly DynamoDBContext _context;

        public TournamentsRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteAsync(TournamentProgressData entity)
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

        public async Task<List<TournamentProgressData>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<TournamentProgressData> search = _context.ScanAsync<TournamentProgressData>(conditions);

                List<TournamentProgressData> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<List<TournamentProgressData>> GetAllBySessionIdAysnc(string sessionId)
        {
            try
            {
                List<ScanCondition> conditions = new List<ScanCondition>
                {
                    new ScanCondition(nameof(TournamentProgressData.SessionId), ScanOperator.Equal, sessionId)
                };
                IAsyncSearch<TournamentProgressData> search = _context.ScanAsync<TournamentProgressData>(conditions);

                List<TournamentProgressData> list = await search.GetRemainingAsync();

                return list ?? new List<TournamentProgressData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<TournamentProgressData> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<TournamentProgressData>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(TournamentProgressData entity)
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
