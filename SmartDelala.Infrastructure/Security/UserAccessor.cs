using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SmartDelala.Application.Contracts.Identity;
using SmartDelala.Application.Features.User;

namespace SmartDelala.Infrastructure.Security;

 
     public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        public UserAccessor(IHttpContextAccessor httpContextAccessor,IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public string? GetUserId()
        {
             return  _httpContextAccessor.HttpContext != null ? _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid) : null;
            
            
        }
    }
 