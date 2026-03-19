using Backend_Test_DynamoDB.Models.Items;

namespace Backend_Test_DynamoDB.Repositories.Inventories
{
    public interface IInventoryItemsRepository
    {
        Task<InventoryItemData> GetAsync(string id);
        Task<bool> SaveAsync(InventoryItemData entity);
        Task<List<InventoryItemData>> GetAllAsync();
        Task<List<InventoryItemData>> GetAllBySessionIdAsync(string sessionId);
        Task<bool> DeleteAsync(InventoryItemData entity);
    }
}
