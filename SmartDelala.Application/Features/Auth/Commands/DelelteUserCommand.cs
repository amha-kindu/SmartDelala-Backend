using MediatR;
using SmartDelala.Application.Responses;

namespace SmartDelala.Application.Features.Auth.Commands;

public sealed record DeleteUserCommand(): IRequest<BaseResponse<Double>>
{ 
    public string UserId { get; set; }  
}