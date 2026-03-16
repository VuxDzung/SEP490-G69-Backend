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
        public bool Success { get; set; }

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

        /// <summary>
        /// How many runs has the player played.
        /// </summary>
        public int RunCount { get; set; }

        [JsonProperty("session")]
        public PlayerGameSession Session { get; set; } = new PlayerGameSession();

        [JsonProperty("exercises")]
        public List<SessionTrainingExercise> Exercises { get; set; } = new List<SessionTrainingExercise>();

        [JsonProperty("deck")]
        public SessionPlayerDeck Deck { get; set; } = new SessionPlayerDeck();

        [JsonProperty("cards")]
        public List<SessionCardData> Cards { get; set; } = new List<SessionCardData>();

        [JsonProperty("character")]
        public SessionCharacterData Character { get; set; } = new SessionCharacterData();

        [JsonProperty("obtained_items")]
        public List<ItemData> ObtainedItems { get; set; } = new List<ItemData>();

        [JsonProperty("shop_items")]
        public List<ShopItemData> ShopItems { get; set; } = new List<ShopItemData>();

        [JsonProperty("tournament_progressions")]
        public List<TournamentProgressData> TournamentProgressions { get; set; } = new List<TournamentProgressData>();
    }
}
