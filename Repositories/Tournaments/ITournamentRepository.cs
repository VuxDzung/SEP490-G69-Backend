using Backend_Test_DynamoDB.Models.Tournaments;

namespace Backend_Test_DynamoDB.Repositories.Tournaments
{
    public interface ITournamentRepository
    {
        Task<TournamentProgressData> GetAsync(string id);
        Task<bool> SaveAsync(TournamentProgressData entity);
        Task<List<TournamentProgressData>> GetAllAsync();
        Task<bool> DeleteAsync(TournamentProgressData entity);
    }
}
