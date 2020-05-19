using AutoMapper;
using ETProject.api.Features.Categorys;
using ETProject.api.Features.Transactions;
using ETProject.api.Features.Users;

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

            CreateMap<Transaction,TransactionDto>();
            CreateMap<TransactionDto,Transaction>();
        }
    }
}