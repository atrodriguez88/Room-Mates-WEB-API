using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Controllers
{
    
    [ApiController]
    [Route("api/users/{userId}/[controller]")]
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

        [HttpGet("{id}")]   // "api/users/{userId}/[controller]/{id}"
        public async Task<IActionResult> GetMessage(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Id");
            var message = await service.GetMessage(id);
            if (message == null)
                return NoContent();
            return Ok(mapper.Map<Message, MessageResource>(message));
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesForUser(int userId, [FromQuery] MessageQueryResource queryObjResource)
        {
            var queryObj = mapper.Map<MessageQueryResource, MessageQuery>(queryObjResource);
            queryObj.UserId = userId;
            var messageList = await service.GetMessagesForUser(queryObj);

            if (messageList == null)
                return NoContent();

            var queryObjResourceList = mapper.Map<List<Message>, List<MessageResource>>(messageList);

            return Ok(queryObjResourceList);
        }

        [HttpGet("thread/{recipientId}")]   // "api/users/{userId}/[controller]/thread/{recipientId}"
        public async Task<IActionResult> GetMessageThread(int userId, int recipientId)
        {
            var messages = await service.GetMessageThread(userId, recipientId);
            var messsagesThread = mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
            return Ok(messsagesThread);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId, [FromBody] SaveMessageResource msgResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profile = await serviceProfile.GetProfile(userId);
            if (profile == null)
                return BadRequest("Can't find user");

            msgResource.SenderMessId = userId;
            var msg = mapper.Map<SaveMessageResource, Message>(msgResource);
            msg.CreatedAt = DateTime.Now;
            msg.CreatedBy = profile.Id.ToString();

            await service.AddMessageAsync(msg);
            await uow.CompleteAsync();

            msg = await service.GetMessage(msg.Id);
            return Ok(mapper.Map<Message, MessageResource>(msg));
        }
    }
}