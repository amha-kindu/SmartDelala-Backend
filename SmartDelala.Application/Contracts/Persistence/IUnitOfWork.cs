
using SmartDelala.Application.Contracts.Identity;

namespace SmartDelala.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task<int> Save(); 
}
