using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Cards
{
    //[DynamoDBTable("SessionCards")]
    public class SessionCardData
    {
        //[DynamoDBHashKey("session_card_id")]

        public string SessionCardId { get; set; } = string.Empty;
        public string RawCardId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;

        public int ObtainedAmount { get; set; }
    }
}
