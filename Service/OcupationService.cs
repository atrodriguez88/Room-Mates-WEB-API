using RoomM.API.Core;
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
        public OcupationService(IOcupationRepository repository)
        {
            this.repository = repository;
        }

        public List<Ocupation> GetOcupations()
        {
            return repository.GetAll().ToList();
        }
    }
}
