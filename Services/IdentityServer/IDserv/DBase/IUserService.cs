using System.Threading.Tasks;
using IDserv.Infrastruct;

namespace IDserv.DBase
{
    public interface IUserService
    {
        Task<OperationDetails> AddIdentityUser(User user);
        Task<User> GetIdentityUserById(int id);
        //Task<User> 
    }
}