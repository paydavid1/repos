using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETProject.api.Features.Category
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppServices categoryAppServices;
        public CategoryController(CategoryAppServices categoryAppServices)
        {
            this.categoryAppServices = categoryAppServices;

        }

        [HttpGet("/api/category/getall/", Name ="GetAllCategory")]
        public async Task<ActionResult> GetAllCategory(){
            return  Ok(await categoryAppServices.GetAllCategory());
        }

        [HttpGet("/api/category/getbyid/{id}", Name ="GetByIdCategory")]
        public async Task<ActionResult> GetByIdAsync(int id){
            CategoryDto categoryDto = await categoryAppServices.GetByIdAsync(id);
            if (categoryDto != null)
                return Ok(categoryDto);
            
            return NotFound($"El id: {id} doesnt exist");

        }


        [HttpPost("/api/category/new/", Name ="AddCategory")]
        public async Task<ActionResult> AddCategory([FromBody]CategoryDto request){
            return Ok(await categoryAppServices.AddCategory(request));
        }

        [HttpPut("/api/category/update/", Name ="UpdateCategory")]
        public async Task<ActionResult> UpdateCategoryAsync([FromBody]CategoryDto categoryDto){
            CategoryDto category = await categoryAppServices.UpdateCategorAsync(categoryDto);
            if (category != null)
                return Ok(category);

            return NotFound($"El id: {categoryDto.Id} doesnt exist");  
        }

        [HttpDelete("/api/category/delete/{id}", Name ="DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(int id)
        {

            CategoryDto category = await categoryAppServices.DeleteCategory(id);
            if (category != null)
                return Ok();

            return NotFound($"El id: {id} doesnt exist");
        }
    }
}