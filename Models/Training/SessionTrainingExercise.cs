using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Training
{
    [DynamoDBTable("TraningExercises")]
    public class SessionTrainingExercise
    {
        [DynamoDBHashKey("entity_id")]
        public string EntityId { get; set; }

        public string RawExerciseId { get; set; }
        public string SessionId { get; set; }
        public int Level { get; set; }
    }
}
