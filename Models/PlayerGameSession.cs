using Amazon.DynamoDBv2.DataModel;
using Backend_Test_DynamoDB.Models.Cards;
using Backend_Test_DynamoDB.Models.Characters;
using Backend_Test_DynamoDB.Models.Items;
using Backend_Test_DynamoDB.Models.Tournaments;
using Backend_Test_DynamoDB.Models.Training;

namespace Backend_Test_DynamoDB.Models
{
    [DynamoDBTable("GameSessions")]
    public class PlayerGameSession
    {
        [DynamoDBHashKey("session_id")]
        public string SessionId { get; set; } = string.Empty;
        public string PlayerId { get; set; } = string.Empty;

        public string RawCharacterId { get; set; } = string.Empty;

        public int CurrentWeek { get; set; } = 0;
        public int CurrentGoldAmount { get; set; } = 0;
        public string ActiveTournamentId { get; set; } = string.Empty;

        //---------------------------------
        // CHARACTER
        //---------------------------------

        public SessionCharacterData Character { get; set; }

        //---------------------------------
        // COLLECTIONS
        //---------------------------------

        public List<SessionCardData> Cards { get; set; } = new List<SessionCardData>();
        public List<InventoryItemData> Items { get; set; } = new List<InventoryItemData>();
        public List<SessionTrainingExercise> Exercises { get; set; } = new List<SessionTrainingExercise>();

        public SessionDeck Deck { get; set; }

        public List<ShopItemData> ShopItems { get; set; } = new List<ShopItemData>();

        //---------------------------------
        // TOURNAMENT
        //---------------------------------
        public List<TournamentProgressData> Tournaments { get; set; } = new List<TournamentProgressData>();
    }
}