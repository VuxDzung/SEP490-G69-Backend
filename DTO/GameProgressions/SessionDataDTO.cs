namespace Backend_Test_DynamoDB.DTO.GameProgressions
{
    public class SessionDataDTO
    {
        public string SessionId { get; set; } = string.Empty;
        public string PlayerId { get; set; } = string.Empty;

        public string RawCharacterId { get; set; } = string.Empty;

        public int CurrentWeek { get; set; } = 0;
        public int CurrentGoldAmount { get; set; } = 0;
        public string ActiveTournamentId { get; set; } = string.Empty;
    }
}