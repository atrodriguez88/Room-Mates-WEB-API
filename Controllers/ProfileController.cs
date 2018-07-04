using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/profiles")]
    public class ProfileController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        private readonly IProfileService service;

        public ProfileController(IMapper mapper, IProfileService service, IUnitOfWork uow)
        {
            this.service = service;
            this.uow = uow;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] SaveProfileResource profileResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profile = mapper.Map<SaveProfileResource, Core.Models.Profile>(profileResource);
            if(profile.MovingDate == null)
                profile.MovingDate = DateTime.Now;

            await service.AddProfileAsync(profile);
            await uow.CompleteAsync();

            profile = await service.GetProfile(profile.Id);            
            return Ok(mapper.Map<Core.Models.Profile, ProfileResource>(profile));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SaveProfile(int id, [FromBody] SaveProfileResource profileResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profile = await service.GetProfile(id);
            if (profile == null)
            {
                return NotFound();
            }
            mapper.Map<SaveProfileResource, Core.Models.Profile>(profileResource, profile);
            profile.MovingDate = DateTime.Now;

            await uow.CompleteAsync();

            return Ok(mapper.Map<Core.Models.Profile, ProfileResource>(profile));
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles()
        {
            var users = await service.GetProfiles();
            if (users == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<IEnumerable<Core.Models.Profile>, IEnumerable<ProfileResource>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await service.GetProfile(id);
            if (profile == null)
            {
                return NotFound();
            }
            var profileResource = mapper.Map<Core.Models.Profile, ProfileResource>(profile);
            return Ok(profileResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await service.GetProfile(id);
            if (profile == null)
            {
                return NotFound();
            }
            service.Remove(profile);
            await uow.CompleteAsync();
            return Ok(id);
        }


        [HttpGet("user/{userId}")]
        public IActionResult GetProfileByUserId(int userId)
        {
            var profilesByUser = service.GetProfileByUserId(userId);
            if (profilesByUser.Count() < 1)
                return NotFound();
            return Ok(mapper.Map<IEnumerable<Core.Models.Profile>, IEnumerable<ProfileResource>>(profilesByUser));
        }

    }
}