using RoomM.API.Core;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Service
{
    public interface IPropertyFeaturesService
    {
        Task<IEnumerable<PropertyFeatures>> GetPropertyFeatures();
    }

    public class PropertyFeaturesService : IPropertyFeaturesService
    {
        private readonly IPropertyFeature repository;
        private readonly ILoggerManager logger;

        public PropertyFeaturesService(IPropertyFeature repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<IEnumerable<PropertyFeatures>> GetPropertyFeatures()
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
