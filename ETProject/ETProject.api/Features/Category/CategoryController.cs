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

        [HttpGet]
        public async Task<ActionResult> GetAllCategory(){
            return  Ok(await categoryAppServices.GetAllCategory());
        }


        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody]CategoryDto request){
            return Ok(await categoryAppServices.AddCategory(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {

            CategoryDto category = await categoryAppServices.DeleteCategory(id);
            if (category != null)
                return Ok();

            return NotFound($"El id: {id} doesnt exist");
        }




    }
}