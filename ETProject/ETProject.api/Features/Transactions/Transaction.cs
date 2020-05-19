using System;
using ETProject.api.Features.Categorys;
using ETProject.api.Features.Users;

namespace ETProject.api.Features.Transactions
{
    public partial class Transaction
    {
        public Transaction()
        {
            
        }

        public int Id { get; private set; }
        public string Description { get; set; }
        public DateTime DateTransaction { get; private set; }
        public double Total { get; private set; }
        public int UserId { get; private set; }
        public int CategoryId { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual User User { get; private set; }

        public sealed class builder{
            private Transaction transaction;

            public builder(string  description, DateTime dateTran, double total, int userId, int categoryId ){
                    transaction = new Transaction(){
                    Description = description,
                    DateTransaction = dateTran,
                    Total = total,
                    UserId = userId,
                    CategoryId = categoryId
                };
            }
            public Transaction build(){
                return transaction;
            }
        }


    }
}