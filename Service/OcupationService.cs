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

        Task<IEnumerable<Ocupation>> GetOcupations();

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

        public async Task<IEnumerable<Ocupation>> GetOcupations()
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
