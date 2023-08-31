using MediatR;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Responses;


namespace SmartDelala.Application.Features.Auth.Queries

{
	public class GetAllUsersQuery : IRequest<PaginatedResponse<UserDtoForAdmin>>
	{

		public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}