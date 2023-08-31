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

public class CreateAdminUserCommandHanlder : IRequestHandler<CreateAdminUserCommand, BaseResponse<AdminUserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateAdminUserCommandHanlder(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<AdminUserDto>> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
    {

        var validator = new AdminCreationDtoValidators();
        
        var validationResult = await validator.ValidateAsync(request.AdminCreationDto);


        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors.Select(q => q.ErrorMessage).ToList().First());


        var role = new RoleDto
        {
            Id = "bcaa5c92-d9d8-4106-8150-91cb40139030",
            Name = "Admin"
        };
        List<RoleDto> temp = new();
        temp.Add(role);

        var applicationRoles = _mapper.Map<List<ApplicationRole>>(temp);


        var applicationUser = _mapper.Map<ApplicationUser>(request.AdminCreationDto);

        var user = await _userRepository.CreateAdminUserAsync(applicationUser, request.AdminCreationDto.Password, applicationRoles);
        var userDto = _mapper.Map<AdminUserDto>(user);

        var response = new BaseResponse<AdminUserDto>();
        response.Success = true;
        response.Message = "Admin Created Successfully";
        response.Value = userDto;
        return response;
    }
}