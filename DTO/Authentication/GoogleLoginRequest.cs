using System.ComponentModel.DataAnnotations;

namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class GoogleLoginRequest
    {
        [Required(ErrorMessage = "Google ID token is required")]
        public string GoogleIdToken { get; set; }
    }
}
