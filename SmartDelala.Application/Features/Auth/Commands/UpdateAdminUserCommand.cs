using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;

namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record UpdateAdminUserCommand() :  IRequest<BaseResponse<AdminUserDto>>

{
   public string UserId { get; set; }  
   public  AdminUpdatingDto UpdatingDto { get; set; }  
}