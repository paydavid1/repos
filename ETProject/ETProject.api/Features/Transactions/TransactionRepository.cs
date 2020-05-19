using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;
using ETProject.api.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Features.Transactions
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Transaction>> GetAsncInclude()
        {
            return await UnitOfWork.Context.Transactions.Include(x => x.Category ).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAsncIncludeByMonthByType(int month, bool type)
        {
              return await UnitOfWork.Context.Transactions.Include(x => x.Category )
              .Where(x => x.Category.Type == type && x.DateTransaction.Month == month ).ToListAsync();
        }
    }
}