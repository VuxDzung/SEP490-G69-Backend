using Backend_Test_DynamoDB.Models.Items;

namespace Backend_Test_DynamoDB.Repositories.Shop
{
    public interface IShopItemRepository
    {
        Task<ShopItemData> GetAsync(string playerId);
        Task SaveAsync(ShopItemData player);
        Task<List<ShopItemData>> GetAllAsync();
        Task DeleteAsync(ShopItemData player);
    }
}
