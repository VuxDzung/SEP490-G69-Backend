using Backend_Test_DynamoDB.DTO.Authentication.Responses;
using Backend_Test_DynamoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test_DynamoDB.Controllers.Authentication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IGoogleAuthService googleAuthService, IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
            _googleAuthService = googleAuthService;
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

        // STEP 1: Start Google Login
        [HttpGet("google/start")]
        public IActionResult StartGoogleLogin()
        {
            string url = _googleAuthService.GenerateGoogleLoginUrl();
            return Redirect(url);
        }

        // STEP 2: Google callback
        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback(string code)
        {
            GoogleLoginResult result = await _googleAuthService.HandleGoogleCallbackAsync(code);
            Console.WriteLine($"Google token id: {result.GoogleIdToken}");
            string redirectUrl = $"mygame://auth?googleIdToken={result.GoogleIdToken}";

            return Redirect(redirectUrl);
        }
    }
}