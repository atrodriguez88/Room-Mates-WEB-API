using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IRuleRepository : IRepository<PropertyRules>
    {
         Task<List<PropertyRules>> GetRules();
    }
}