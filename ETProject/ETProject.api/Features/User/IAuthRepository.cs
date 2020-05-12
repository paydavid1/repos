using System.Threading.Tasks;
using ETProject.api.Features.Interfaces;

namespace ETProject.api.Features.User
{
    public interface IAuthRepository : IRepository<User>
    {
         Task<bool> UserExists(string userName);
         Task<User> GetUserByUserIdAsync(string userName);


    }
}