using SmartDelala.Application.Exceptions;

namespace SmartDelala.Application.Features.Common;

public class PaginatedQuery
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
