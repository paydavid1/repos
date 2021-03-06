using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETProject.api.Features.Transactions
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class TransactionController: ControllerBase
    {
        private readonly TransactionAppServices transactionAppServices;
        public TransactionController(TransactionAppServices transactionAppServices)
        {
            this.transactionAppServices = transactionAppServices;

        }

        [HttpGet("/api/Transaction/getall/{id}", Name ="GetAllTransaction")]
        public async Task<ActionResult> GetAllTransaction(int id){
            return  Ok(await transactionAppServices.GetAllTransaction(id));
        }
        [HttpGet("/api/Transaction/{type}/{month}/{userId}/", Name ="GetAllTransactionByMonthByType")]
        public async Task<ActionResult> GetAllTransactionByMonthByType(bool type, int month, int userId){
            return  Ok(await transactionAppServices.GetByMonthByType(userId,month,type));
        }

        [HttpGet("/api/Transaction/{month}/{userId}/", Name ="GetAllTransactionByMonth")]
        public async Task<ActionResult> GetAllTransactionByMonth(int month,int userId){
            return  Ok(await transactionAppServices.GetBalance(userId,month));
        }

        [HttpGet("/api/Transaction/getbyid/{id}", Name ="GetByIdTransaction")]
        public async Task<ActionResult> GetByIdAsync(int id){
            TransactionDto transactionDto = await transactionAppServices.GetByIdAsync(id);
            if (transactionDto != null)
                return Ok(transactionDto);
            
            return NotFound($"El id: {id} doesnt exist");

        }


        [HttpPost("/api/Transaction/new/", Name ="AddTransaction")]
        public async Task<ActionResult> AddTransaction([FromBody]TransactionDto request){
            return Ok(await transactionAppServices.AddTransaction(request));
        }

        [HttpPut("/api/Transaction/update/", Name ="UpdateTransaction")]
        public async Task<ActionResult> UpdateTransactionAsync([FromBody]TransactionDto transactionDto){
            TransactionDto transaction = await transactionAppServices.UpdateCategorAsync(transactionDto);
            if (transaction != null)
                return Ok(transaction);

            return NotFound($"El id: {transactionDto.Id} doesnt exist");  
        }

        [HttpDelete("/api/Transaction/delete/{id}", Name ="DeleteTransaction")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {

            TransactionDto transaction = await transactionAppServices.DeleteTransaction(id);
            if (transaction != null)
                return Ok();

            return NotFound($"El id: {id} doesnt exist");
        }

    }
}