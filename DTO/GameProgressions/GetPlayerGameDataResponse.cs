using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Models.Cards;
using Backend_Test_DynamoDB.Models.Characters;
using Backend_Test_DynamoDB.Models.Items;
using Backend_Test_DynamoDB.Models.Tournaments;
using Backend_Test_DynamoDB.Models.Training;
using Newtonsoft.Json;

namespace Backend_Test_DynamoDB.DTO.GameProgressions
{
    public class GetPlayerGameDataResponse
    {
        #region Response handler
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; } = string.Empty;

        #endregion

        #region Player info
        [JsonProperty("player_id")]
        public string PlayerId { get; set; } = string.Empty;
        [JsonProperty("player_name")]
        public string PlayerName { get; set; } = string.Empty;
        [JsonProperty("legacy_points")]
        public int LegacyPoints { get; set; }
        [JsonProperty("last_sync_time")]
        public DateTime LastSyncedTime { get; set; }
        [JsonProperty("current_run")]
        public int CurrentRun { get; set; }
        #endregion

        [JsonProperty("session")]
        public SessionDataDTO Session { get; set; } = new SessionDataDTO();

        #region Session contents
        [JsonProperty("character")]
        public SessionCharacterData Character { get; set; } = new SessionCharacterData();

        [JsonProperty("exercises")]
        public List<SessionTrainingExercise> Exercises { get; set; } = new List<SessionTrainingExercise>();

        [JsonProperty("deck")]
        public SessionDeck Deck { get; set; } = new SessionDeck();

        [JsonProperty("cards")]
        public List<SessionCardData> Cards { get; set; } = new List<SessionCardData>();


        [JsonProperty("obtained_items")]
        public List<InventoryItemData> ObtainedItems { get; set; } = new List<InventoryItemData>();

        [JsonProperty("shop_items")]
        public List<ShopItemData> ShopItems { get; set; } = new List<ShopItemData>();


        [JsonProperty("tournaments")]
        public List<TournamentProgressData> Tournaments { get; set; } = new List<TournamentProgressData>();
        #endregion
    }
}
