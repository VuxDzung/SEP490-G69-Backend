using Backend_Test_DynamoDB.DTO.Authentication.Responses;
using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories;
using Google.Apis.Auth;

namespace Backend_Test_DynamoDB.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IConfiguration _config;
        private readonly IPlayerRepository _playerRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public GoogleAuthService(
            IConfiguration config,
            IPlayerRepository playerRepository,
            IJwtTokenService jwtTokenService)
        {
            _config = config;
            _playerRepository = playerRepository;
            _jwtTokenService = jwtTokenService;
        }

        public string GenerateGoogleLoginUrl()
        {
            string clientId = _config["Google:ClientId"];
            string redirectUri = _config["Google:RedirectUri"];

            return "https://accounts.google.com/o/oauth2/v2/auth" +
                   $"?client_id={clientId}" +
                   $"&redirect_uri={redirectUri}" +
                   "&response_type=code" +
                   "&scope=openid%20email%20profile";
        }

        public async Task<GoogleLoginResult> HandleGoogleCallbackAsync(string code)
        {
            string tokenEndpoint = "https://oauth2.googleapis.com/token";

            var http = new HttpClient();

            var response = await http.PostAsync(tokenEndpoint,
                new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "code", code },
                    { "client_id", _config["Google:ClientId"] },
                    { "client_secret", _config["Google:ClientSecret"] },
                    { "redirect_uri", _config["Google:RedirectUri"] },
                    { "grant_type", "authorization_code" }
                }));

            GoogleTokenResponse tokenData = await response.Content.ReadFromJsonAsync<GoogleTokenResponse>();

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenData.id_token);

            string googleId = payload.Subject;

            return new GoogleLoginResult
            {
                GoogleIdToken = googleId,
            };
        }
    }
}
