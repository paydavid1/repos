using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETProject.api.Features.Category
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppServices categoryAppServices;
        public CategoryController(CategoryAppServices categoryAppServices)
        {
            this.categoryAppServices = categoryAppServices;

        }

        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody]CategoryDto request){
            return Ok(await categoryAppServices.AddCategory(request));
        }

        
    }
}