using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppWithIdentity.Models;
public class User : IdentityUser
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
    [MaxLength(18, ErrorMessage = "Password must not exceed 18 characters")]
    public string Password { get; set; } = string.Empty;
}