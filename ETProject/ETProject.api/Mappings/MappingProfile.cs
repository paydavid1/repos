using AutoMapper;
using ETProject.api.Features.Category;

namespace ETProject.api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto,Category>();
        }
    }
}