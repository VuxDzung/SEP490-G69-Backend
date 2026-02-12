using Backend_Test_DynamoDB.DTO.Authentication.Responses;
namespace Backend_Test_DynamoDB.Services
{
    public interface IGoogleAuthService
    {
        string GenerateGoogleLoginUrl();
        Task<GoogleLoginResult> HandleGoogleCallbackAsync(string code);
    }
}