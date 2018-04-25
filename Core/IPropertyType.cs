using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IPropertyType
    {
         Task<List<PropertyType>> GetPropertyTypes();
    }
}