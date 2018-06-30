using RoomM.API.Core;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Service
{
    public interface IOcupationService {

        List<Ocupation> GetOcupations();

    }
    public class OcupationService : IOcupationService
    {
        private readonly IOcupationRepository repository;
        private readonly ILoggerManager logger;

        public OcupationService(IOcupationRepository repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public List<Ocupation> GetOcupations()
        {
            logger.LogInfo("Here is info message from our values controller.");
            logger.LogDebug("Here is debug message from our values controller.");
            logger.LogWarn("Here is warn message from our values controller.");
            logger.LogError("Here is error message from our values controller.");

            return repository.GetAll().ToList();
        }
    }
}
