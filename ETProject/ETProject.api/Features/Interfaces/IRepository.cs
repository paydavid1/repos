using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETProject.api.Features.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAsnc();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);
         
    }
}