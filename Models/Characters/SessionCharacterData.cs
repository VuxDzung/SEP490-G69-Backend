using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Characters
{
    //[DynamoDBTable("SessionCharacters")]
    public class SessionCharacterData
    {
        //-----------------------------------------
        // INDENTIFIER
        //-----------------------------------------
        //[DynamoDBHashKey("entity_id")]
        public string Id { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string RawCharacterId { get; set; } = string.Empty;


        //-----------------------------------------
        // CHARACTER-RUNTIME-STATS
        //-----------------------------------------
        public float CurrentMaxVitality { get; set; }
        public float CurrentPower { get; set; }
        public float CurrentIntelligence { get; set; }
        public float CurrentStamina { get; set; }
        public float CurrentDef { get; set; }
        public float CurrentAgi { get; set; }
        public float CurrentEnergy { get; set; }
        public float CurrentMood { get; set; }
        public int CurrentRP { get; set; }
    }
}
