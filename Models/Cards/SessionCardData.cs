using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Cards
{
    [DynamoDBTable("SessionCards")]
    public class SessionCardData
    {
        /// <summary>
        /// Session card id apply the following format
        /// <SESSION_ID>:<RAW_CARD_ID>
        /// </summary>
        [DynamoDBHashKey("session_card_id")]
        public string SessionCardId { get; set; } = string.Empty;
        public string RawCardId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;

        public int ObtainedAmount { get; set; }
    }
}
