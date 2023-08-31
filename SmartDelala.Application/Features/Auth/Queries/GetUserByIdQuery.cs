using MediatR;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Responses;

namespace SmartDelala.Application.Features.Auth.Queries

{
	public class GetUserByIdQuery : IRequest<BaseResponse<UserDto>>
	{
	public string UserId;
    }
}