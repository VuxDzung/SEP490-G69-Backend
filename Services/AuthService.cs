using Backend_Test_DynamoDB.DTO.Authentication.Responses;
using Backend_Test_DynamoDB.DTO.Authentication;
using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories;
using FirebaseAdmin.Auth;

namespace Backend_Test_DynamoDB.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly FirebaseAuth _firebaseAuth;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IPlayerRepository playerRepository, IJwtTokenService jwtTokenService, ILogger<AuthService> logger)
        {
            _playerRepository = playerRepository;
            _jwtTokenService = jwtTokenService;
            _firebaseAuth = FirebaseAuth.DefaultInstance;
            _logger = logger;
        }

        public async Task<AuthResponse> AuthenticateWithFirebaseAsync(string firebaseIdToken)
        {
            try
            {
                // Step 1: Verify Firebase token
                Console.WriteLine("Verify Firebase token");
                FirebaseToken decodedToken = await _firebaseAuth.VerifyIdTokenAsync(firebaseIdToken);
                Console.WriteLine("Verify Firebase token completed!");
                string uid = decodedToken.Uid;

                // Step 2: Get or create player
                var player = await _playerRepository.GetAsync(uid);

                string actionType = "Login";

                if (player == null)
                {
                    player = new PlayerData
                    {
                        PlayerId = uid,
                        PlayerName = $"Player_{uid.Substring(0, 6)}",
                        LegacyPoints = 0,
                        CreatedAt = DateTime.UtcNow,
                        LastLoggedIn = DateTime.UtcNow
                    };

                    await _playerRepository.SaveAsync(player);
                    actionType = "SignUp";
                }
                else
                {
                    player.LastLoggedIn = DateTime.UtcNow;
                    await _playerRepository.SaveAsync(player);
                }

                // Step 3: Generate Game JWT
                string accessToken = _jwtTokenService.GenerateAccessToken(player);
                string refreshToken = _jwtTokenService.GenerateRefreshToken(player);

                return new AuthResponse
                {
                    Success = true,
                    Message = $"{actionType} successful",
                    Data = new AuthData
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                        PlayerId = player.PlayerId,
                        PlayerName = player.PlayerName,
                        LegacyPoints = player.LegacyPoints
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firebase authentication failed");
                return new AuthResponse
                {
                    Success = false,
                    Message = "Invalid authentication token"
                };
            }
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var principal = _jwtTokenService.ValidateRefreshToken(refreshToken);

            if (principal == null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Invalid refresh token"
                };
            }

            string playerId = principal.FindFirst("uid")?.Value;

            var player = await _playerRepository.GetAsync(playerId);

            string newAccessToken = _jwtTokenService.GenerateAccessToken(player);

            return new AuthResponse
            {
                Success = true,
                Data = new AuthData
                {
                    AccessToken = newAccessToken,
                    PlayerId = player.PlayerId,
                    PlayerName = player.PlayerName
                }
            };
        }
    }
}
