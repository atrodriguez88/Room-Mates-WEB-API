using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<Profile> GetProfile(int id);
        Task<IEnumerable<Profile>> GetProfiles();
    }
}