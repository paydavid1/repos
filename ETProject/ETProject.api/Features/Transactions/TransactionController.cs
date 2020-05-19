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

        [HttpGet("/api/Transaction/getall/", Name ="GetAllTransaction")]
        public async Task<ActionResult> GetAllTransaction(){
            return  Ok(await transactionAppServices.GetAllTransaction());
        }
        [HttpGet("/api/Transaction/getbymonthtype/", Name ="GetAllTransactionByMonthByType")]
        public async Task<ActionResult> GetAllTransactionByMonthByType(TransactionBalanceDto request){
            return  Ok(await transactionAppServices.GetByMonthByType(request.month,request.type));
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