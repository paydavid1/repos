using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Features.Transactions
{
    public class TransactionAppServices
    {
        
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper mapper;

        public IUnitOfWork UnitOfWork { get; }


        public TransactionAppServices(IUnitOfWork unitOfWork, ITransactionRepository transactionRepository, IMapper mapper )
        {
            
            this.UnitOfWork = unitOfWork;
            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }

         public async Task<TransactionDto> AddTransaction(TransactionDto nuevoTransaction)
        {

            Transaction newTransaction = new Transaction.builder(nuevoTransaction.Description,nuevoTransaction.DateTransaction,nuevoTransaction.Total,nuevoTransaction.UserId,nuevoTransaction.CategoryId).build();

            bool created = await transactionRepository.AddAsync(newTransaction);

            if (created)
                await UnitOfWork.CompleteAsync();
            //return new TransactionDto() { Id = newTransaction.Id, Description = newTransaction.Description, Type = newTransaction.Type };
            return mapper.Map<TransactionDto>(newTransaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransaction(int id)
        {
        
           // IEnumerable<Transaction> transactionsDB = await transactionRepository.GetAsnc();
            IEnumerable<Transaction> transactionsDB = await transactionRepository.GetAsncInclude(id);
            IEnumerable<TransactionDto> transactionsDto = mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDto>>(transactionsDB);
            return transactionsDto;

        }

       

        public async Task<TransactionDto> UpdateCategorAsync(TransactionDto TransactionDto){
            Transaction Transaction  =  await transactionRepository.GetByIdAsync(TransactionDto.Id);
            if (Transaction != null)
            {
                mapper.Map(TransactionDto,Transaction);
                transactionRepository.UpdateAsync(Transaction);
                await UnitOfWork.CompleteAsync();
            }

            return mapper.Map<TransactionDto>(Transaction);
        }

        public async Task<TransactionDto> DeleteTransaction(int id){
            Transaction Transaction = await transactionRepository.GetByIdAsync(id);
            if (Transaction != null){
                transactionRepository.DeleteAsync(Transaction);
                await UnitOfWork.CompleteAsync();
            }
            return mapper.Map<TransactionDto>(Transaction);
        }

        public async Task<TransactionDto> GetByIdAsync(int id){
            Transaction transaction = await transactionRepository.GetByIdAsync(id);
            return mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetByMonthByType(int idUser, int month, bool type){
            IEnumerable<Transaction> transactionsDB = await transactionRepository.GetAsncIncludeByMonthByType(idUser,month,type);
            IEnumerable<TransactionDto> transactionsDto = mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDto>>(transactionsDB);
            return transactionsDto;
            
        }

        public async Task<decimal> GetBalance(int idUser, int month){
            var ingresos = await GetByMonthByType(idUser,month,false);
            var egresos = await GetByMonthByType(idUser,month,true);

            return ingresos.Sum(i => (decimal)i.Total)  - egresos.Sum(e => (decimal)e.Total);
        }
    }
}