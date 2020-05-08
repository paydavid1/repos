using System.Collections.Generic;
using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Persistence.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get {return unitOfWork;} }
        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAsync(T entity)
        {
           bool created = false;

           var save = await unitOfWork.Context.Set<T>().AddAsync(entity);
           if(save != null)
                created = true;
            return created;
        }

        public void DeleteAsync(T entity)
        {
             unitOfWork.Context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAsnc()
        {
            return await unitOfWork.Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            unitOfWork.Context.Set<T>().Update(entity);
        }
    }
}