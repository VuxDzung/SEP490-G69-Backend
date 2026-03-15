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
        [JsonProperty("player_data")]
        public PlayerData PlayerData { get; set; } = new PlayerData();

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
