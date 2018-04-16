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

namespace Room_Mates.Controllers
{
    [Route("/api/rooms")]
    public class RoomController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRoomRepository repository;
        private readonly IUnitOfWork uow;
        public RoomController(IMapper mapper, IRoomRepository repository, IUnitOfWork uow)
        {
            this.uow = uow;
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var room = await repository.GetRooms();

            if (room == null)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<Room>, List<RoomResource>>(room));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await repository.GetRoom(id);

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

            await repository.AddRoomAsync(room);
            await uow.CompleteAsync();

            room = await repository.GetRoom(room.Id);

            return Ok(mapper.Map<Room, RoomResource>(room));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SaveRoom(int id, [FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = await repository.GetRoom(id);
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
            var room = await repository.GetRoom(id, includeRelated: false);
            if (room == null)
            {
                return NotFound();
            }
            repository.Remove(room);
            await uow.CompleteAsync();
            return Ok(id);
        }
    }
}