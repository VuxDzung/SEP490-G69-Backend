namespace Backend_Test_DynamoDB.DTO.Authentication.Responses
{
    public class ErrorResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public Dictionary<string, string[]> ValidationErrors { get; set; }
    }
}
