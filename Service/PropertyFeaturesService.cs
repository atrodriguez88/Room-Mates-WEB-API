using RoomM.API.Core;
using RoomM.API.Core.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models.Domain;

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
