using MediatR;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Responses;

namespace SmartDelala.Application.Features.Auth.Queries

{
	public class GetAllRolesQuery : IRequest<BaseResponse<List<RoleDto>>>
	{
	
    }
}