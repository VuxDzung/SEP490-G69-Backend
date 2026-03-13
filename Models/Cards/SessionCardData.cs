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
        public string SessionCardId { get; set; }
        public string RawCardId { get; set; }
        public string SessionId { get; set; }

        public int ObtainedAmount { get; set; }
    }
}
