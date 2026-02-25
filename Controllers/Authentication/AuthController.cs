using Backend_Test_DynamoDB.DTO.Authentication;
using Backend_Test_DynamoDB.DTO.Authentication.Responses;
using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Services;
using Backend_Test_DynamoDB.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend_Test_DynamoDB.Controllers.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private IPlayerManagementService _playerManageService;
        private readonly ILogger<AuthController> _logger;
        private readonly GoogleDesktopClientOptions _googleClientOptions;

        public AuthController(GoogleDesktopClientOptions googleClientOptions, IAuthService authService, IPlayerManagementService managementService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
            _playerManageService = managementService;
            _googleClientOptions = googleClientOptions;
        }

        [HttpPost("firebase-login")]
        public async Task<IActionResult> FirebaseLogin()
        {
            string authHeader = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader))
                return Unauthorized();

            string firebaseToken = authHeader.Replace("Bearer", "").Trim();

            AuthResponse response = await _authService.AuthenticateWithFirebaseAsync(firebaseToken);

            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleAuthRequest request)
        {
            var tokens = await ExchangeCodeAsync(request.AuthorizationCode, request.CodeVerifier);

            //var payload = await GoogleJsonWebSignature.ValidateAsync(tokens.id_token);

            //string uid = payload.Subject;

            //var customToken = await FirebaseAdmin.Auth.FirebaseAuth
            //    .DefaultInstance
            //    .CreateCustomTokenAsync(uid);

            WindowsLoginByGGResponse response = new WindowsLoginByGGResponse
            {
                TokenId = tokens.id_token
            };

            return Ok(response);
        }

        private async Task<GoogleTokenResponse> ExchangeCodeAsync(string code, string codeVerifier)
        {
            var values = new Dictionary<string, string>
            {
                { "code", code },
                { "client_id", _googleClientOptions.ClientId },
                { "client_secret", _googleClientOptions.ClientSecret },  
                { "redirect_uri", _googleClientOptions.RedirectUri },
                { "grant_type", "authorization_code" },
                { "code_verifier", codeVerifier }
            };

            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(
                "https://oauth2.googleapis.com/token",
                content);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Google token exchange failed: {json}");
            }
            Console.WriteLine($"Received: {json}");
            return JsonSerializer.Deserialize<GoogleTokenResponse>(json);
        }

        #region Dev only
        [HttpGet("getAllPlayers")]
        public async Task<List<PlayerData>> GetAllPlayers()
        {
            return await _playerManageService.GetAllPlayers();
        }
        [HttpDelete("deletePlayer")]
        public async Task<IActionResult> DeletePlayer(string playerId)
        {
            bool success = await _playerManageService.DeletePlayer(playerId); 
            if (success) 
                return Ok();

            return BadRequest();
        }
        #endregion
    }

    public class GoogleTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
            public string refresh_token { get; set; }
        public string scope {  get; set; }
        public string token_type { get; set; }
        public string id_token { get; set; }
    }

    public class WindowsLoginByGGResponse
    {
        public string TokenId { get; set; }
    }
}