using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ETProject.api.Features.Transactions;

namespace ETProject.api.Features.Categorys
{
    public class Category
    {

        public Category()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public bool Type { get; private set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public sealed class builder{
            private Category categories;

            public builder(string description, bool type){
                    categories = new Category(){
                    Description = description,
                    Type = type
                };
            }
            public Category build(){
                return categories;
            }
        }




        
    }
}