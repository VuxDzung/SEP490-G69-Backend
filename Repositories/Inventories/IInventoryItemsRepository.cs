using Backend_Test_DynamoDB.Models.Items;

namespace Backend_Test_DynamoDB.Repositories.Inventories
{
    public interface IInventoryItemsRepository
    {
        Task<ItemData> GetAsync(string playerId);
        Task SaveAsync(ItemData player);
        Task<List<ItemData>> GetAllAsync();
        Task DeleteAsync(ItemData player);
    }
}
