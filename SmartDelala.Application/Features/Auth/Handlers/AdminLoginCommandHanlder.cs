using MediatR;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Features.Auth.Commands;

namespace SmartDelala.Application.Features.Auth.Handlers;

public sealed class AdminLoginCommandHandler : IRequestHandler<AdminLoginCommand, BaseResponse<LoginResponse>>
{
    private readonly IUserRepository _userRepository;

    public AdminLoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async   Task<BaseResponse<LoginResponse>> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {

        var result = await _userRepository.LoginByAdminAsync(request.LoginRequest.UserName, request.LoginRequest.Password);

        var response = new BaseResponse<LoginResponse>();
        response.Message = "Logged In Successfully";
        response.Success = true;
        response.Value = result;
        return response;
    }
}