

using SmartDelala.Domain.Common;

namespace SmartDelala.Application.Common.Dtos.Security;
public class AdminUpdatingDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }

}