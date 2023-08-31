using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;


namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record CreateUserCommand(): IRequest<BaseResponse<UserDto>>
{ 
    public UserCreationDto UserCreationDto { get; set; }  
}
