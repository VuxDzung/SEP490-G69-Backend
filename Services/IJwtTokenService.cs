using Backend_Test_DynamoDB.Models;
using System.Security.Claims;

namespace Backend_Test_DynamoDB.Services
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(PlayerData player);
        string GenerateRefreshToken(PlayerData player);
        ClaimsPrincipal ValidateRefreshToken(string token);
    }
}
