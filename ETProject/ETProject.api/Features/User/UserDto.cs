using System.ComponentModel.DataAnnotations;

namespace ETProject.api.Features.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        [Required]
        public string UserId { get;  set; }
        [Required]
        [StringLength(8,MinimumLength = 4,ErrorMessage ="Password between 4 -8")]
        public string Password { get; set; }
        
    }
}