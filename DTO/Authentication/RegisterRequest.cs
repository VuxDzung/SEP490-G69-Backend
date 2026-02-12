using System.ComponentModel.DataAnnotations;

namespace Backend_Test_DynamoDB.DTO.Authentication
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$",
            ErrorMessage = "Password must contain at least one uppercase, one lowercase, and one number")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Player name is required")]
        [MinLength(3, ErrorMessage = "Player name must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Player name must not exceed 20 characters")]
        public string PlayerName { get; set; }
    }
}