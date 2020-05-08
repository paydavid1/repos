using System;
using System.Threading.Tasks;
using ETProject.api.Persistence.Data;

namespace ETProject.api.Features.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         ETDbContext Context {get;}
         Task CompleteAsync();

         
    }
}