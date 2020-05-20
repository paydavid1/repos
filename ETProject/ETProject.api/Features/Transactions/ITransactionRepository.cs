using System.Collections.Generic;
using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Features.Transactions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
         Task<IEnumerable<Transaction>> GetAsncInclude(int id);
         Task<IEnumerable<Transaction>> GetAsncIncludeByMonthByType(int idUser, int month, bool type);
         
    }
}