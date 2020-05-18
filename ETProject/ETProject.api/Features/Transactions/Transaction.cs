using System;
using ETProject.api.Features.Categorys;

namespace ETProject.api.Features.Transactions
{
    public partial class Transaction
    {
        public Transaction()
        {
            
        }

        public int Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
       // public virtual Category User { get; set; }


    }
}