using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IAuthRepository
    {
         Task Register(ApplicationUser user, string pass);
         Task Login(string user, string pass);
         bool UserExist(string user);
    }
}