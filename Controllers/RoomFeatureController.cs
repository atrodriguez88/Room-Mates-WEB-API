using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;

namespace RoomM.API.Controllers
{
    [Route("/api/roomfeatures")]
    public class RoomFeatureController : Controller
    {
        private readonly RoomFeatureRepository repository;
        private readonly IMapper mapper;

        public RoomFeatureController(RoomFeatureRepository repository, IMapper mapper)
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