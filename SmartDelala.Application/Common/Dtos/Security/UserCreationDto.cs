

using Microsoft.AspNetCore.Http;
using SmartDelala.Domain.Common;

namespace SmartDelala.Application.Common.Dtos.Security;
public class UserCreationDto
{
    public RoleDto Roles { get; set; } = new();
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }

    public IFormFile? Profilepicture { get; set; }

}