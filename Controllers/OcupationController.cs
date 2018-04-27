using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;

namespace RoomM.API.Controllers
{
    [Route("/api/ocupations")]
    public class OcupationController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOcupation repository;
        public OcupationController(IOcupation repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet()]
        public async Task<IActionResult> GetOcupations()
        {
            var ocupations = await repository.GetOcupations();
            if (ocupations == null)
                return NoContent();
            return Ok(mapper.Map<List<Ocupation>, List<KeyValuePairResource>>(ocupations));
        }

    }
}