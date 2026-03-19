using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Items;
using Amazon.DynamoDBv2.DocumentModel;

namespace Backend_Test_DynamoDB.Repositories.Inventories
{
    public class InventoryRepository : IInventoryItemsRepository
    {
        private readonly DynamoDBContext _context;

        public InventoryRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }
        public async Task<bool> DeleteAsync(InventoryItemData entity)
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

        public async Task<List<InventoryItemData>> GetAllAsync()
        {
            try
            {
                var conditions = new List<ScanCondition>();
                IAsyncSearch<InventoryItemData> search = _context.ScanAsync<InventoryItemData>(conditions);

                List<InventoryItemData> list = await search.GetRemainingAsync();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<InventoryItemData>();
            }
        }

        public async Task<List<InventoryItemData>> GetAllBySessionIdAsync(string sessionId)
        {
            try
            {
                List<ScanCondition> conditions = new List<ScanCondition>
                {
                    new ScanCondition(nameof(InventoryItemData.SessionId), ScanOperator.Equal, sessionId)
                }; 
                IAsyncSearch<InventoryItemData> search = _context.ScanAsync<InventoryItemData>(conditions);

                List<InventoryItemData> list = await search.GetRemainingAsync();

                return list ?? new List<InventoryItemData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<InventoryItemData>();
            }
        }

        public async Task<InventoryItemData> GetAsync(string id)
        {
            try
            {
                return await _context.LoadAsync<InventoryItemData>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> SaveAsync(InventoryItemData entity)
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
