using Backend_Test_DynamoDB.Models.Cards;
using Backend_Test_DynamoDB.Models.Characters;
using Backend_Test_DynamoDB.Models.Items;
using Backend_Test_DynamoDB.Models.Tournaments;
using Backend_Test_DynamoDB.Models.Training;
using Newtonsoft.Json;

namespace Backend_Test_DynamoDB.DTO.GameProgressions
{
    public class UnsertPlayerGameDataRequest
    {
        [JsonProperty("player_data")]
        public PlayerInfoDTO PlayerData { get; set; } = new PlayerInfoDTO();

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
