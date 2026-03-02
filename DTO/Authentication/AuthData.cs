namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class AuthData
    {
        public string AuthAction { get; set; }
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int LegacyPoints { get; set; }
    }
}
