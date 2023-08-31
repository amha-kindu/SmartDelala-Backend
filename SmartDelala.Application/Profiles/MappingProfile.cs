using AutoMapper;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Domain.Models;

namespace SmartDelala.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {        
        #region User Mappings

        CreateMap<ApplicationRole, RoleDto>()
          .ReverseMap();
        CreateMap<ApplicationUser, UserCreationDto>()
          .ReverseMap();
        CreateMap<ApplicationUser, UserCreationDto>()
          .ReverseMap();
        CreateMap<ApplicationUser, UserUpdatingDto>()
          .ReverseMap();
        CreateMap<ApplicationUser, UserDto>()
          .ReverseMap();
        CreateMap<ApplicationUser, UserDtoForAdmin>()
          .ReverseMap();
        CreateMap<ApplicationUser, AdminUserDto>()
          .ReverseMap();
        CreateMap<ApplicationUser, AdminCreationDto>()
          .ReverseMap();

        #endregion User
    }
}