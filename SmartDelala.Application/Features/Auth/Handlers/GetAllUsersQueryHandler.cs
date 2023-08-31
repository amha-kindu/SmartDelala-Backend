
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

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginatedResponse<UserDtoForAdmin>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

     
    public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<UserDtoForAdmin>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allApplicationUsers = await _userRepository.GetUsersAsync(request.PageNumber,request.PageSize);


        var usersWithRoles = new List<UserDtoForAdmin>();
        foreach (var u in allApplicationUsers.Value)
        {
            var user = new UserDtoForAdmin
            {
                Id = u.Id,
                FullName = u.FullName,
                PhoneNumber = u.PhoneNumber,
                Age = u.Age
            };
            if (u.LastLogin.HasValue && (DateTime.UtcNow - u.LastLogin.Value).TotalDays < 30)
            {
                user.StatusByLogin = "ACTIVE";
            }
            else
            {
                user.StatusByLogin = "INACTIVE";
            }
            var roles = await _userRepository.GetUserRolesAsync(u);
            var roleDtos = _mapper.Map<List<RoleDto>>(roles);
            user.Roles.AddRange(roleDtos);
            usersWithRoles.Add(user);
        }
        
        return new PaginatedResponse<UserDtoForAdmin>(){
            Message= "Users Fetched Successfully",
            Value= usersWithRoles,
            Count= allApplicationUsers.Count,
            PageNumber= request.PageNumber,
            PageSize= request.PageSize
        };

    }
}