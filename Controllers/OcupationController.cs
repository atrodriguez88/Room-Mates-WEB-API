using System.Collections.Generic;
using System.Linq;
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
        private readonly IOcupationService service;

        public OcupationController(IOcupationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet()]
        public async Task<IActionResult> GetOcupations()
        {
            //var ocupations = await service.GetOcupations();
            var ocupations = await service.GetOcupations();
            if (ocupations == null)
                return NoContent();
            return Ok(mapper.Map<List<Ocupation>, List<KeyValuePairResource>>(ocupations.ToList()));
        }

    }
}