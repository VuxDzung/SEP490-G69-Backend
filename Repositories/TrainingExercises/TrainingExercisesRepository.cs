using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Training;
using Amazon.DynamoDBv2.DocumentModel;

namespace Backend_Test_DynamoDB.Repositories.TrainingExercises
{
    public class TrainingExercisesRepository : ITrainingExercisesRepository
    {
        private readonly DynamoDBContext _context;

        public TrainingExercisesRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteAsync(SessionTrainingExercise entity)
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

        public async Task<List<SessionTrainingExercise>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<SessionTrainingExercise> search = _context.ScanAsync<SessionTrainingExercise>(conditions);

                List<SessionTrainingExercise> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<List<SessionTrainingExercise>> GetAllBySessionIdAsync(string sessionId)
        {
            try
            {
                List<ScanCondition> conditions = new List<ScanCondition>
                {
                    new ScanCondition(nameof(SessionTrainingExercise.SessionId), ScanOperator.Equal, sessionId)
                };

                var search = _context.ScanAsync<SessionTrainingExercise>(conditions);

                List<SessionTrainingExercise> list = await search.GetRemainingAsync();

                return list ?? new List<SessionTrainingExercise>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<SessionTrainingExercise>();
            }
        }

        public async Task<SessionTrainingExercise> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<SessionTrainingExercise>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(SessionTrainingExercise entity)
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
