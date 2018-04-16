using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IProfileRepository
    {
        Task<Profile> GetProfile(int id, bool? includeRelated = true);
        Task<List<Profile>> GetProfiles();

        Task AddProfileAsync(Profile profile);
        void Remove(Profile profile);
    }
}