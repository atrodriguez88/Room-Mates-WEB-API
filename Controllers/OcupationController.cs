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
        private readonly ILogger<OcupationController> logger;

        public OcupationController(IOcupationService repository, IMapper mapper, ILogger<OcupationController> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet()]
        public async Task<IActionResult> GetOcupations()
        {
            logger.LogInformation("Index page says hello");
            //var ocupations = await repository.GetOcupations();
            var ocupations = repository.GetOcupations();
            if (ocupations == null)
                return NoContent();
            return Ok(mapper.Map<List<Ocupation>, List<KeyValuePairResource>>(ocupations));
        }

    }
}