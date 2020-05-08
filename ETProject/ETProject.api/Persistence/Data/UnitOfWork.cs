using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ETDbContext Context { get;}


        public UnitOfWork(ETDbContext context)
        {
            Context = context;
        }

        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}