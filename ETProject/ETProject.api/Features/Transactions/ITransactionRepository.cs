using System.Collections.Generic;
using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Features.Transactions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
         Task<IEnumerable<Transaction>> GetAsncInclude();
         Task<IEnumerable<Transaction>> GetAsncIncludeByMonthByType(int month, bool type  );
    }
}