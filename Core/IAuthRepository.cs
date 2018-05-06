using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IAuthRepository
    {
         Task<bool> Register(ApplicationUser user, string pass);
         Task<bool> Login(string user, string pass);
         Task<bool> UserExist(string user);
         object BuildToken(ApplicationUser userInfo);
    }
}