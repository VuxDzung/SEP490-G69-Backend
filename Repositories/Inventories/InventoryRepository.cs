using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Items;

namespace Backend_Test_DynamoDB.Repositories.Inventories
{
    public class InventoryRepository : IInventoryItemsRepository
    {
        private readonly DynamoDBContext _context;

        public InventoryRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }
        public async Task<bool> DeleteAsync(ItemData entity)
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

        public async Task<List<ItemData>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<ItemData> search = _context.ScanAsync<ItemData>(conditions);

                List<ItemData> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<ItemData> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<ItemData>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(ItemData entity)
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
