

using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Domain.Models;

namespace SmartDelala.Application.Contracts.Identity;

public interface IJwtService
{
    Task<TokenDto> GenerateToken(ApplicationUser user);
    Task<TokenDto?> RefreshToken(TokenDto tokenDto);
}