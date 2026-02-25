namespace Backend_Test_DynamoDB.DTO.Profile
{
    public class UpdatePlayerNameRequest
    {
        public string PlayerId { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
    }
}
