using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Core.Repository
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<Profile> GetProfile(int id);
        Task<IEnumerable<Profile>> GetProfiles(FilterProfile filter);
        Task AddPhoto(int id, Photo photo);
    }
}