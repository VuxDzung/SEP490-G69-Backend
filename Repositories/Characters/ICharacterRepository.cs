using Backend_Test_DynamoDB.Models.Characters;

namespace Backend_Test_DynamoDB.Repositories.Characters
{
    public interface ICharacterRepository
    {
        Task<SessionCharacterData> GetAsync(string playerId);
        Task SaveAsync(SessionCharacterData player);
        Task<List<SessionCharacterData>> GetAllAsync();
        Task DeleteAsync(SessionCharacterData player);
    }
}
