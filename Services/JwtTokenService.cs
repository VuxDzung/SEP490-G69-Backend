using Backend_Test_DynamoDB.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend_Test_DynamoDB.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateAccessToken(PlayerData player)
        {
            var claims = new[]
            {
                new Claim("uid", player.PlayerId),
                new Claim("name", player.PlayerName),
                new Claim("points", player.LegacyPoints.ToString())
            };

            return GenerateToken(claims, 15); // 15 phút
        }

        public string GenerateRefreshToken(PlayerData player)
        {
            var claims = new[]
            {
                new Claim("uid", player.PlayerId)
            };

            return GenerateToken(claims, 7 * 24 * 60); // 7 ngày
        }

        private string GenerateToken(IEnumerable<Claim> claims, int minutes)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Secret"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(minutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidateRefreshToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Secret"]);

                return tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true
                }, out _);
            }
            catch
            {
                return null;
            }
        }
    }
}