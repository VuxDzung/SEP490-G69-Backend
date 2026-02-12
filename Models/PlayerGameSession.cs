using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models
{
    public class PlayerGameSession
    {
        [DynamoDBHashKey]
        public string PlayerId { get; set; }
        public string SessionId { get; set; }

        public string SessionName { get; set; }
        public string CharacterId { get; set; }
        public int CurrentWeek { get; set; }
        public bool IsCompleted { get; set; }
    }
}