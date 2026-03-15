using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Cards
{
    [DynamoDBTable("PlayerDeck")]
    public class SessionPlayerDeck
    {
        [DynamoDBHashKey("session_id")]
        public string SessionId { get; set; } = string.Empty;
        public string[] CardIds { get; set; } = new string[0];
    }
}
