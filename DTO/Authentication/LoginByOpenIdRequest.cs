using System.Text.Json.Serialization;

namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class LoginByOpenIdRequest
    {
        [JsonPropertyName("player_id")]
        public string PlayerId { get; set; }

        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }

        [JsonPropertyName("player_name")]
        public string PlayerName { get; set; } // Optional

        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }

        [JsonPropertyName("device_type")]
        public string DeviceType { get; set; }
    }
}