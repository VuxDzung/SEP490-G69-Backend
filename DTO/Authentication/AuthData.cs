namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class AuthData
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int LegacyPoints { get; set; }
        public string ActionType { get; set; } // "Login" or "SignUp"
        public long TokenExpiresAt { get; set; } // Unix timestamp
    }
}
