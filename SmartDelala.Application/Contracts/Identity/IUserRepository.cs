
using System.Threading.Tasks;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Common.Dtos.Statistics;
using SmartDelala.Application.Responses;
using SmartDelala.Domain.Models;

namespace SmartDelala.Application.Contracts.Identity;
public interface IUserRepository
{
	Task<ApplicationUser> FindByEmailAsync(string email);
	Task<ApplicationUser> FindByIdAsync(string userId);
	Task<ApplicationUser> CreateUserAsync(ApplicationUser user, List<ApplicationRole> roles);
	Task<ApplicationUser> CreateAdminUserAsync(ApplicationUser user, string password, List<ApplicationRole> roles);
	Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
	Task<List<ApplicationRole>> GetUserRolesAsync(ApplicationUser? user);
	Task<ApplicationUser> UpdateUserAsync(string userId, ApplicationUser user);
	Task<ApplicationUser> UpdateAdminUserAsync(string userId, ApplicationUser user);
	Task<PaginatedResponse<ApplicationUser>> GetUsersAsync( int pageNumber = 1,
		int pageSize = 10);
	Task DeleteUserAsync(string userId);
	Task<bool> CheckEmailExistence(string email, string? userId);
	Task<ApplicationUser> GetUserById(string userId);
	Task ResetPassword(string userId, string password);
	Task<LoginResponse> LoginAsync(string phoneNumber);
	Task<LoginResponse> LoginByAdminAsync(string userName, string password);
	Task<TokenDto?> RefreshToken(TokenDto tokenDto);
	Task<PaginatedResponse<ApplicationUser>> GetUsersByRoleAsync(string role,  int pageNumber = 1,
		int pageSize = 10); 
}
