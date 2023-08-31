
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Features.Auth.Commands;
using SmartDelala.Application.Features.Auth.Queries;
using SmartDelala.Application.Responses;
using SmartDelala.Domain.Models;

namespace SmartDelala.Application.Features.Auth.Handlers;

public sealed class GetUserByQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var applicationUser = await _userRepository.GetUserById(request.UserId);
        Console.WriteLine(request.UserId);
        Console.WriteLine("checking");


        var user = new UserDto
        {

            FullName = applicationUser.FullName,
            PhoneNumber = applicationUser.PhoneNumber,
            Age = applicationUser.Age

        };
        if (applicationUser.LastLogin.HasValue && (DateTime.UtcNow - applicationUser.LastLogin.Value).TotalDays < 30)
        {
            user.StatusByLogin = "ACTIVE";
        }
        else
        {
            user.StatusByLogin = "INACTIVE";
        }
        
        var roles = await _userRepository.GetUserRolesAsync(applicationUser);
        Console.WriteLine(roles.Count);
        var roleDtos = _mapper.Map<List<RoleDto>>(roles);
        user.Roles.AddRange(roleDtos);

        var response = new BaseResponse<UserDto>();
        response.Success = true;
        response.Message = "Fetched In Successfully";
        response.Value = user;
        return response;

    }
}