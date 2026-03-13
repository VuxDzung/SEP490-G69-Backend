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

        public DateTime LastSyncedTime { get; set; }

        public DeviceInfo LastSyncedDevice { get; set; } = null;

        public List<DeviceInfo> Devices { get; set; } = new List<DeviceInfo>();

        /// <summary>
        /// How many runs has the player played.
        /// </summary>
        public int RunCount { get; set; }
    }
}