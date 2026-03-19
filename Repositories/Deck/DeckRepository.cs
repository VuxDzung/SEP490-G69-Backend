using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Backend_Test_DynamoDB.Models.Cards;

namespace Backend_Test_DynamoDB.Repositories.Deck
{
    public class DeckRepository : IDeckRepository
    {
        private readonly DynamoDBContext _context;

        public DeckRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContextBuilder().WithDynamoDBClient(() => dynamoDb).Build();
        }

        public async Task<bool> DeleteDeckById(string playerId)
        {
            try
            {
                await _context.DeleteAsync<SessionDeck>(playerId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<SessionDeck> GetDeckById(string playerId)
        {
            try
            {
                SessionDeck playerDeck = await _context.LoadAsync<SessionDeck>(playerId);
                return playerDeck;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> SaveAsync(SessionDeck deck)
        {
            try
            {
                await _context.SaveAsync(deck);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
