namespace Backend_Test_DynamoDB.Models.Tournaments
{
    public class TournamentParticipantData
    {
        public string Id { get; set; } = string.Empty;

        public string CharacterId { get; set; } = string.Empty;

        public bool IsPlayer { get; set; }

        public int SlotIndex { get; set; }

        public float TotalStats { get; set; }

        public bool IsEliminated { get; set; }
    }
}
