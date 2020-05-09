using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Features.Category
{
    public class CategoryAppServices
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public IUnitOfWork UnitOfWork { get; }
        
        public CategoryAppServices(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper )
        {
            
            this.UnitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> AddCategory(CategoryDto nuevoCategory)
        {

            Category newCategory = new Category.builder(nuevoCategory.Description, nuevoCategory.Type).build();

            bool created = await categoryRepository.AddAsync(newCategory);

            if (created)
                await UnitOfWork.CompleteAsync();
            //return new CategoryDto() { Id = newCategory.Id, Description = newCategory.Description, Type = newCategory.Type };
            return mapper.Map<CategoryDto>(newCategory);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
        
            IEnumerable<Category> categoriesDB = await categoryRepository.GetAsnc();
            IEnumerable<CategoryDto> categoriesDto = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categoriesDB);
            return categoriesDto;

        }

        public async Task<CategoryDto> DeleteCategory(int id){
            Category category = await categoryRepository.GetByIdAsync(id);
            if (category != null){
                categoryRepository.DeleteAsync(category);
                await UnitOfWork.CompleteAsync();

            }
                

            return mapper.Map<CategoryDto>(category);
        }


    }
}