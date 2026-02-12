namespace Backend_Test_DynamoDB.DTO.Authentication.Responses
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public AuthData Data { get; set; }
    }
}
