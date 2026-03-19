using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Tournaments
{
    //[DynamoDBTable("TournamentProgress")]
    public class TournamentProgressData
    {
        //[DynamoDBHashKey("entity_id")]

        public string Id { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string RawTournamentId { get; set; } = string.Empty;

        public int CurrentRoundIndex { get; set; }

        public List<TournamentParticipantData> Participants { get; set; } = new List<TournamentParticipantData>();
        public List<TournamentParticipantData> SemiFinalParticipants { get; set; } = new List<TournamentParticipantData>();
        public List<TournamentParticipantData> FinalParticipants { get; set; } = new List<TournamentParticipantData>();
        public List<TournamentParticipantData> CurrentRoundParticipants { get; set; } = new List<TournamentParticipantData>();

        public bool WaitingForPlayerBattle { get; set; }

        public bool IsBattleFinished { get; set; }
        public bool IsPlayerWon { get; set; }

        public string PendingEnemyId { get; set; }
    }
}
