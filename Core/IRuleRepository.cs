using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IRuleRepository
    {
         Task<List<PropertyRules>> GetRules();
    }
}