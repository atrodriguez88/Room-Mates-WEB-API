using RoomM.API.Core;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Service
{
    public interface IRoomFeatureService
    {
        Task<IEnumerable<RoomFeatures>> GetRoomFeatures();
    }

    public class RoomFeatureService : IRoomFeatureService
    {
        private readonly IRoomFeature repository;
        private readonly ILoggerManager logger;

        public RoomFeatureService(IRoomFeature repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<IEnumerable<RoomFeatures>> GetRoomFeatures()
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
