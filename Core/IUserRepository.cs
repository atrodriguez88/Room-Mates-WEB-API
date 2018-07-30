using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models.Auth;

namespace RoomM.API.Core
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserByEmail(string id);
    }
}