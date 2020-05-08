using System.ComponentModel.DataAnnotations;

namespace ETProject.api.Features.Category
{
    public class Category
    {
        [Key]
        public int Guid { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        
    }
}