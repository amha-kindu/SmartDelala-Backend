
using AutoMapper;
using MediatR;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Features.Auth.Commands;
using SmartDelala.Application.Responses;
using SmartDelala.Domain.Models;

namespace Application.Security.Handlers.CommandHandlers;

public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResponse<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var response = new BaseResponse<UserDto>();
        var applicationUser = _mapper.Map<ApplicationUser>(request.User);

        var updatedUser = await _userRepository.UpdateUserAsync(request.UserId, applicationUser);
        
        var userDto = _mapper.Map<UserDto>(updatedUser);

        response.Success = true;
        response.Message = "User Updated Successfully";
        response.Value = userDto;
        return response;





    }
}