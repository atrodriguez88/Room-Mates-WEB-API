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
    [Route("/api/roomfeatures")]
    public class RoomFeatureController : Controller
    {
        private readonly IRoomFeature repository;
        private readonly IMapper mapper;

        public RoomFeatureController(IRoomFeature repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoomFeatures()
        {
            var rooms = await repository.GetRoomFeatures();
            if (rooms == null)
                return NoContent();
            return Ok(mapper.Map<List<RoomFeatures>, List<KeyValuePairResource>>(rooms));
        }
    }
}