

using SmartDelala.Domain.Common;

namespace SmartDelala.Application.Common.Dtos.Security;
public class UserDtoForAdmin
{

    public List<RoleDto> Roles { get; } = new();
    public string Id {get;set;}
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }
    public string StatusByLogin {get;set;}
    public string ProfilePicture { get; set; } = string.Empty;
    

}