using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUser(int id);
    }
}