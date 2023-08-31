using Microsoft.Extensions.Configuration;
using SmartDelala.Application.Contracts.Persistence;

namespace SmartDelala.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly SmartDelalaDbContext _context;
	private readonly IConfiguration _configuration;

	

	public UnitOfWork(SmartDelalaDbContext context, IConfiguration configuration)
	{
		_context = context;
		_configuration = configuration;
	}
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }


	public async Task<int> Save()
	{
		return await _context.SaveChangesAsync();
	}
}
