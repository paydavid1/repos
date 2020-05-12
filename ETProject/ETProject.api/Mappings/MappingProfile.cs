using AutoMapper;
using ETProject.api.Features.Category;
using ETProject.api.Features.User;

namespace ETProject.api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto,Category>();

            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();
        }
    }
}