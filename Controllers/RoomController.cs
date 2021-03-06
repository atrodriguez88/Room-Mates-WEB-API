using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;
using RoomM.API.Core.Repository;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/rooms")]
    public class RoomController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRoomService service;
        private readonly IPropertyType propertyService;
        private readonly IUnitOfWork uow;
        public RoomController(IMapper mapper, IRoomService service, IPropertyType propertyService,  IUnitOfWork uow)
        {
            this.uow = uow;
            this.service = service;
            this.propertyService = propertyService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRooms(RoomQueryResource roomQueryResource)
        {
            var filter = Mapper.Map<RoomQueryResource, RoomQuery>(roomQueryResource);
            var rooms = await service.GetRooms(filter);

            if (rooms == null)
            {
                return NoContent();
            }
            var roomResources = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);
            return Ok(roomResources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await service.GetRoom(id);

            if (room == null)
                return NotFound();

            var roomResource = mapper.Map<Room, RoomResource>(room);
            return Ok(roomResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = mapper.Map<SaveRoomResource, Room>(roomResource);
            room.AvailableFrom = DateTime.Now;

            room.PropertyType = await propertyService.FirstOrDefault( p => p.Id == roomResource.PropertyId);

            room.CreatedAt = DateTime.Now;
            room.CreatedBy = room.UserId.ToString();

            await service.AddRoomAsync(room);
            await uow.CompleteAsync();

            room = await service.GetRoom(room.Id);

            return Ok(mapper.Map<Room, RoomResource>(room));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SaveRoom(int id, [FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = await service.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            mapper.Map(roomResource, room);
            room.AvailableFrom = DateTime.Now;
            room.PropertyType = await propertyService.FirstOrDefault(p => p.Id == roomResource.PropertyId);

            room.UpdatedAt = DateTime.Now;
            room.CreatedBy = room.UserId.ToString();


            await uow.CompleteAsync();

            return Ok(mapper.Map<Room, RoomResource>(room));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await service.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            service.Remove(room);

            room.DeletedAt = DateTime.Now;
            room.DeletedBy = room.UserId.ToString();

            await uow.CompleteAsync();
            return Ok(id);
        }

        [HttpGet("user/{userId}")]
        public IActionResult Get(int userId)
        {
            var roomByUser = service.GetRoomsByUserId(userId);
            if(!roomByUser.Any())
                return NotFound();
            return Ok(mapper.Map<IEnumerable<Room>,IEnumerable<RoomResource>>(roomByUser));
        }
    }
}