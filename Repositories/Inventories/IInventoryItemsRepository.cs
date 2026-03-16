using Backend_Test_DynamoDB.Models.Items;

namespace Backend_Test_DynamoDB.Repositories.Inventories
{
    public interface IInventoryItemsRepository
    {
        Task<ItemData> GetAsync(string id);
        Task<bool> SaveAsync(ItemData entity);
        Task<List<ItemData>> GetAllAsync();
        Task<bool> DeleteAsync(ItemData entity);
    }
}
