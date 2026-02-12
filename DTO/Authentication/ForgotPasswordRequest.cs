using System.ComponentModel.DataAnnotations;

namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}
