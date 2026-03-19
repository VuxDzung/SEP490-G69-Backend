using Backend_Test_DynamoDB.Models;
using Newtonsoft.Json;

namespace Backend_Test_DynamoDB.DTO.GameProgressions
{
    public class UpdateLastSyncTimeRequest
    {
        [JsonProperty("player_id")]
        public string PlayerId { get; set; }

        [JsonProperty("last_sync_time")]
        public DateTime LastSyncTime { get; set; }

        [JsonProperty("sync_device")]
        public DeviceInfo SyncDevice { get; set; }
    }
}
