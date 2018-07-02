using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Service;

namespace Room_Mates.Controllers
{
    [Route("/api/rooms")]
    public class RoomController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRoomService service;
        private readonly IUnitOfWork uow;
        public RoomController(IMapper mapper, IRoomService service, IUnitOfWork uow)
        {
            this.uow = uow;
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var room = await service.GetRooms();

            if (room == null)
            {
                return NoContent();
            }

            return Ok(room);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await service.GetRoom(id);

            if (room == null)
                return NotFound();

            //var roomResource = mapper.Map<Room, RoomResource>(room);
            return Ok(room);
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

            mapper.Map<SaveRoomResource, Room>(roomResource, room);
            room.AvailableFrom = DateTime.Now;

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
            await uow.CompleteAsync();
            return Ok(id);
        }

        [HttpGet("user/{userId}")]
        public IActionResult Get(int userId)
        {
            var roomByUser = service.GetRoomsByUserId(userId);
            if(roomByUser.Count() < 1)
                return NotFound();
            return Ok(mapper.Map<IEnumerable<Room>,IEnumerable<RoomResource>>(roomByUser));
        }
    }
}