using MediatR;
using AutoMapper;
using SmartDelala.Domain.Models;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Exceptions;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Features.Auth.Commands;
using SmartDelala.Application.Common.Dtos.Security.Validators;

namespace SmartDelala.Application.Features.Auth.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<UserDto>>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<BaseResponse<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{

        var validator = new UserCreationDtoValidators();
        
        var validationResult = await validator.ValidateAsync(request.UserCreationDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.Select(q => q.ErrorMessage).ToList().First());

        var role = request.UserCreationDto.Roles;
        List<RoleDto> temp = new() ;
        temp.Add(role);
        
        var applicationRoles = _mapper.Map<List<ApplicationRole>>(temp);

		var applicationUser = _mapper.Map<ApplicationUser>(request.UserCreationDto);
		applicationUser.CreatedAt = DateTime.UtcNow;

		var user = await _userRepository.CreateUserAsync(applicationUser, applicationRoles);

		var userDto = _mapper.Map<UserDto>(user);

		var response = new BaseResponse<UserDto>();
		response.Success = true;
		response.Message = "User Created Successfully";
		response.Value = userDto;
		return response;
	}
}