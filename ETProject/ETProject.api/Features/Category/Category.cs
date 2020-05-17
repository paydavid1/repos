using System.ComponentModel.DataAnnotations;

namespace ETProject.api.Features.Category
{
    public class Category
    {

        public Category()
        {
            
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public bool Type { get; private set; }

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