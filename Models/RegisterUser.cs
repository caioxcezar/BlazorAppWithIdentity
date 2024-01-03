using System.ComponentModel.DataAnnotations;

namespace BlazorAppWithIdentity.Models;
public class RegisterUser
{
    [Required]
    [RegularExpression(@"^[a-z0-9_-]{3,15}$", ErrorMessage = "User name must have between 3 and 15 characters and don't have especial characters. ")]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [MinLength(5, ErrorMessage = "Password must have at least 5 characters")]
    [MaxLength(50, ErrorMessage = "Password must not exceed 50 characters")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid E-mail")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
    [MaxLength(18, ErrorMessage = "Password must not exceed 18 characters")]
    public string Password { get; set; } = string.Empty;
    [Required]
    [MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
    [MaxLength(18, ErrorMessage = "Password must not exceed 18 characters")]
    public string ConfirmPassword { get; set; } = string.Empty;
}