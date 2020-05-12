using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;
using ETProject.api.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ETProject.api.Features.User
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(IUnitOfWork unitOfWork ):base(unitOfWork)
        {
            
        }
        public Task<User> Login(string userName, string pass)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Register(User user, string pass)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UserExists(string userName)
        {
           if(await UnitOfWork.Context.Set<User>().AnyAsync(x => x.UserId == userName))
                return true;
            return false;

        }

        public async Task<User> GetUserByUserIdAsync(string userName)
        {
            return await UnitOfWork.Context.Set<User>().FirstOrDefaultAsync(x => x.UserId == userName) ;
        }
    }
}
