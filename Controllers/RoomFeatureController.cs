using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/roomfeatures")]
    public class RoomFeatureController : Controller
    {
        private readonly IRoomFeatureService service;
        private readonly IMapper mapper;

        public RoomFeatureController(IRoomFeatureService service, IMapper mapper)
        {
            this.mapper = mapper;
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoomFeatures()
        {
            var rooms = await service.GetRoomFeatures();
            if (rooms == null)
                return NoContent();
            return Ok(mapper.Map<IEnumerable<RoomFeatures>, IEnumerable<KeyValuePairResource>>(rooms));
        }
    }
}