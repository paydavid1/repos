using System;

namespace ETProject.api.Features.Transactions
{
    public class TransactionDto
    {
        
        public int Id { get;  set; }
        public string Description { get; set; }
        public DateTime DateTransaction { get;  set; }
        public double Total { get;  set; }
        public int UserId { get;  set; }
        public int CategoryId { get;  set; }
        public string CategoryDescription { get; set; }

    }
}