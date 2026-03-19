using Backend_Test_DynamoDB.Models.Items;

namespace Backend_Test_DynamoDB.Repositories.Shop
{
    public interface IShopItemRepository
    {
        Task<ShopItemData> GetAsync(string id);
        Task<bool> SaveAsync(ShopItemData entity);
        Task<List<ShopItemData>> GetAllAsync();
        Task<List<ShopItemData>> GetAllBySessionIdAsync(string sessionId);
        Task<bool> DeleteAsync(ShopItemData entity);
    }
}
