using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.QueryString;
using RoomM.API.Service;
using Profile = RoomM.API.Core.Models.Domain.Profile;

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
            var profile = mapper.Map<SaveProfileResource, Profile>(profileResource);

            profile.CreatedAt = DateTime.Now;
            profile.CreatedBy = profile.UserId.ToString();


            await service.AddProfileAsync(profile);
            await uow.CompleteAsync();

            profile = await service.GetProfile(profile.Id);            
            return Ok(mapper.Map<Profile, ProfileResource>(profile));
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
            mapper.Map(profileResource, profile);
            profile.MovingDate = DateTime.Now;

            profile.UpdatedAt = DateTime.Now;
            profile.UpdatedBy = profile.UserId.ToString();

            await uow.CompleteAsync();

            return Ok(mapper.Map<Profile, ProfileResource>(profile));
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles(ProfileQueryResource queryResource)
        {
            var filter = Mapper.Map<ProfileQueryResource, ProfileQuery>(queryResource);
            var users = await service.GetProfiles(filter);
            if (users == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileResource>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await service.GetProfile(id);
            if (profile == null)
            {
                return NotFound();
            }
            var profileResource = mapper.Map<Profile, ProfileResource>(profile);
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

            profile.DeletedAt = DateTime.Now;
            profile.DeletedBy = profile.UserId.ToString();
            await uow.CompleteAsync();
            return Ok(id);
        }


        [HttpGet("user/{userId}")]
        public IActionResult GetProfileByUserId(int userId)
        {
            var profilesByUser = service.GetProfileByUserId(userId);
            if (!profilesByUser.Any())
                return NotFound();
            return Ok(mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileResource>>(profilesByUser));
        }

    }
}