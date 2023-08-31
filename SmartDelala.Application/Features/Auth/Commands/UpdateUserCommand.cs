using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;

namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record UpdateUserCommand() :  IRequest<BaseResponse<UserDto>>

{
   public string UserId { get; set; }  
   public  UserUpdatingDto User { get; set; }  
}