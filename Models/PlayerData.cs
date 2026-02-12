using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models
{
    [DynamoDBTable("PlayerData")]
    public class PlayerData
    {
        [DynamoDBHashKey("player_id")]
        public string PlayerId { get; set; }

        public string PlayerName { get; set; } = string.Empty;
        public string PlayerEmail { get; set; } = string.Empty;
        public int LegacyPoints { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public List<ConnectedDevice> Devices { get; set; }
    }
}