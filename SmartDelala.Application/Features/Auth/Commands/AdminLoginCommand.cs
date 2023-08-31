using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;

namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record AdminLoginCommand() : IRequest<BaseResponse<LoginResponse>>
{ 
 public LoginRequestByAdmin LoginRequest { get; set; }  
}