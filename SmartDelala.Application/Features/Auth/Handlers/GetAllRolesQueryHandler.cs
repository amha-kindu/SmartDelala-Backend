using MediatR;
using AutoMapper;
using SmartDelala.Domain.Models;
using Microsoft.AspNetCore.Identity;
using SmartDelala.Application.Responses;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Features.Auth.Queries;

namespace SmartDelala.Application.Features.Auth.Handlers;

public sealed class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, BaseResponse<List<RoleDto>>>
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(RoleManager<ApplicationRole> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<RoleDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var allApplicationRoles =  _roleManager.Roles.ToList();
        var allRoles = allApplicationRoles.Select(role => _mapper.Map<RoleDto>(role)).ToList();

        var response = new BaseResponse<List<RoleDto>>();
        response.Success = true;
        response.Message = "Roles Fetching Successful";
        response.Value = allRoles;
        return response;
       
    }
}