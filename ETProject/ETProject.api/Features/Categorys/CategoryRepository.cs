using ETProject.api.Features.Interfaces;
using ETProject.api.Persistence.Data;

namespace ETProject.api.Features.Categorys
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork ):base(unitOfWork)
        {
            
        }
    }
}