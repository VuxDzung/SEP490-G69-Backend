using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Training
{
    //[DynamoDBTable("TraningExercises")]
    public class SessionTrainingExercise
    {
        //[DynamoDBHashKey("entity_id")]

        public string Id { get; set; } = string.Empty;

        public string ExerciseId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}
