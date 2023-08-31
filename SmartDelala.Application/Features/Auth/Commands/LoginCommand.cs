using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;

namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record LoginCommand() : IRequest<BaseResponse<LoginResponse>>
{ 
    public LoginRequest LoginRequest { get; set; }  
}
