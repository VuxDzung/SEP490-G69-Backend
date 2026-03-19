using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Items;
using Amazon.DynamoDBv2.DocumentModel;
using Backend_Test_DynamoDB.Models.Tournaments;

namespace Backend_Test_DynamoDB.Repositories.Shop
{
    public class ShopItemsRepository : IShopItemRepository
    {
        private readonly DynamoDBContext _context;

        public ShopItemsRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteAsync(ShopItemData entity)
        {
            try
            {
                await _context.DeleteAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<ShopItemData>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<ShopItemData> search = _context.ScanAsync<ShopItemData>(conditions);

                List<ShopItemData> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<List<ShopItemData>> GetAllBySessionIdAsync(string sessionId)
        {
            try
            {
                List<ScanCondition> conditions = new List<ScanCondition>
                {
                    new ScanCondition(nameof(ShopItemData.SessionId), ScanOperator.Equal, sessionId)
                }; 
                IAsyncSearch<ShopItemData> search = _context.ScanAsync<ShopItemData>(conditions);

                List<ShopItemData> list = await search.GetRemainingAsync();

                return list ?? new List<ShopItemData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<ShopItemData>();
            }
        }

        public async Task<ShopItemData> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<ShopItemData>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(ShopItemData entity)
        {
            try
            {
                await _context.SaveAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
