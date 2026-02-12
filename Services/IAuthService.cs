using Backend_Test_DynamoDB.DTO.Authentication.Responses;

namespace Backend_Test_DynamoDB.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateWithFirebaseAsync(string firebaseIdToken);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken);
    }
}