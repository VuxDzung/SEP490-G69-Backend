namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class GoogleAuthRequest
    {
        public string AuthorizationCode { get; set; }
        public string CodeVerifier { get; set; }
    }
}
