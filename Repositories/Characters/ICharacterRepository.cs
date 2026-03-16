using Backend_Test_DynamoDB.Models.Characters;

namespace Backend_Test_DynamoDB.Repositories.Characters
{
    public interface ICharacterRepository
    {
        Task<SessionCharacterData> GetAsync(string id);

        Task<bool> SaveAsync(SessionCharacterData entity);

        Task<List<SessionCharacterData>> GetAllAsync();

        Task<bool> DeleteAsync(SessionCharacterData entity);
    }
}
