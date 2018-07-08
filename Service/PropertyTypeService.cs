using RoomM.API.Core.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Repository;

namespace RoomM.API.Service
{
    public interface IPropertyTypeService
    {
        Task<IEnumerable<PropertyType>> GetPropertyTypes();
    }

    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IPropertyType repository;
        private readonly ILoggerManager logger;

        public PropertyTypeService(IPropertyType repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypes()
        {
            try
            {
                return await repository.GetAll();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }
    }    
}
