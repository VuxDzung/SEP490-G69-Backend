using Backend_Test_DynamoDB.Models.Training;

namespace Backend_Test_DynamoDB.Repositories.TrainingExercises
{
    public interface ITrainingExercisesRepository
    {
        Task<SessionTrainingExercise> GetAsync(string id);
        Task<bool> SaveAsync(SessionTrainingExercise entity);
        Task<List<SessionTrainingExercise>> GetAllAsync();
        Task<List<SessionTrainingExercise>> GetAllBySessionIdAsync(string sessionId);
        Task<bool> DeleteAsync(SessionTrainingExercise entity);
    }
}
