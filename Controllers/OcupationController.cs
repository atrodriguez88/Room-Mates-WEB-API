using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/ocupations")]
    public class OcupationController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOcupationService repository;

        public OcupationController(IOcupationService repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet()]
        public async Task<IActionResult> GetOcupations()
        {
            //var ocupations = await repository.GetOcupations();
            var ocupations = repository.GetOcupations();
            if (ocupations == null)
                return NoContent();
            return Ok(mapper.Map<List<Ocupation>, List<KeyValuePairResource>>(ocupations));
        }

    }
}