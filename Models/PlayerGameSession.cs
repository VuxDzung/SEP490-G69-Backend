using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models
{
    [DynamoDBTable("GameSessions")]
    public class PlayerGameSession
    {
        [DynamoDBHashKey("session_id")]
        public string SessionId { get; set; } = string.Empty;
        public string PlayerId { get; set; } = string.Empty;

        /// <summary>
        /// This is the raw character id
        /// Ex: ch_0001, ch_0002, etc.
        /// </summary>
        public string RawCharacterId { get; set; } = string.Empty;

        public int CurrentWeek { get; set; } = 0;
        public int CurrentGoldAmount { get; set; } = 0;
    }
}