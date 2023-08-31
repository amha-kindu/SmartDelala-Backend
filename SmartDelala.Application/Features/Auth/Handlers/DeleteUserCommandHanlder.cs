using MediatR;
using AutoMapper;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Features.Auth.Commands;

namespace SmartDelala.Application.Features.Auth.Handlers;

public class DeleltUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseResponse<Double>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleltUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<Double>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {

        await _userRepository.DeleteUserAsync(request.UserId);

        var response = new BaseResponse<Double>();
        response.Success = true;
        response.Message = "User Deleted Successfully";
        response.Value = 1;
        return response;
    }
}