namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class LoginByOpenIdResponse
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int LegacyPoints { get; set; }
        public string ActionType { get; set; }
    }
}