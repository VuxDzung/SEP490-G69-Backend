using Backend_Test_DynamoDB.Models.Tournaments;

namespace Backend_Test_DynamoDB.Repositories.Tournaments
{
    public interface ITournamentRepository
    {
        Task<TournamentProgressData> GetAsync(string playerId);
        Task SaveAsync(TournamentProgressData player);
        Task<List<TournamentProgressData>> GetAllAsync();
        Task DeleteAsync(TournamentProgressData player);
    }
}
