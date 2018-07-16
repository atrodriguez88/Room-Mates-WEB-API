using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService service;
        private readonly IProfileService serviceProfile;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public MessageController(IMessageService service, IProfileService serviceProfile, IUnitOfWork uow, IMapper mapper)
        {
            this.service = service;
            this.serviceProfile = serviceProfile;
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessage(int userId)
        {
            if (userId <= 0)
                return BadRequest("Invalid Id");
            var message = await service.GetMessage(userId);
            if (message == null)
                return NoContent();
            return Ok(mapper.Map<Message, MessageResource>(message));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId, [FromBody] MessageResource msgResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profile = await serviceProfile.GetProfile(userId);
            if (profile == null)
                return BadRequest("Can't find user");

            msgResource.SenderMessId = userId;
            var msg = mapper.Map<MessageResource, Message>(msgResource);
            msg.CreatedAt = DateTime.Now;
            msg.CreatedBy = profile.Id.ToString();

            await service.AddMessageAsync(msg);
            await uow.CompleteAsync();

            msg = await service.GetMessage(msg.Id);
            return Ok(mapper.Map<Message, MessageResource>(msg));
        }
    }
}