using Microsoft.AspNetCore.Identity;
using SmartDelala.Domain.Common;

namespace SmartDelala.Domain.Models;

public class ApplicationUser : IdentityUser
{
  
	public int Age { get; set; }
	public string FullName { get; set; } = string.Empty;
    public DateTime? LastLogin {get;set;} 
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ad

}
