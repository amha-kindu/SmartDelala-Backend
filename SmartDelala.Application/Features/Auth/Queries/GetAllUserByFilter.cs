using MediatR;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Responses;

namespace SmartDelala.Application.Features.Auth.Queries;

public class GetUsersByFilterQuery : IRequest<PaginatedResponse<UserDtoForAdmin>>
{
    public string PhoneNumber { get; set; }
    public string RoleName { get; set; }
    public string FullName { get; set; }
    public string Status { get; set; } // "ACTIVE" or "INACTIVE"
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
