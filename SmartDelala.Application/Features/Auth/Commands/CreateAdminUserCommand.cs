using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;

namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record CreateAdminUserCommand(): IRequest<BaseResponse<AdminUserDto>>
{ 
    public AdminCreationDto AdminCreationDto { get; set; }  
}