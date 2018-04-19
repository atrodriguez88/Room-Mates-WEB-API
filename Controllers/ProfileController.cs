using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;

namespace RoomM.API.Controllers
{
    [Route("/api/profiles")]
    public class ProfileController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        private readonly IProfileRepository repository;
        public ProfileController(IMapper mapper, IProfileRepository repository, IUnitOfWork uow)
        {
            this.repository = repository;
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
            profile.MovingDate = DateTime.Now;

            await repository.AddProfileAsync(profile);
            await uow.CompleteAsync();

            return Ok(mapper.Map<Core.Models.Profile, ProfileResource>(profile));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SaveProfile(int id, [FromBody] SaveProfileResource profileResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profile = await repository.GetProfile(id);
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
            var users = await repository.GetProfiles();
            if (users == null)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<Core.Models.Profile>, List<ProfileResource>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var profile = await repository.GetProfile(id);
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
            var profile = await repository.GetProfile(id, includeRelated: false);
            if (profile == null)
            {
                return NotFound();
            }
            repository.Remove(profile);
            await uow.CompleteAsync();
            return Ok(id);
        }


        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetProfileByUserId(int userId)
        {
            var profilesByUser = await repository.GetProfileByUserId(userId);
            if (profilesByUser.Count < 1)
                return NotFound();
            return Ok(mapper.Map<List<Core.Models.Profile>, List<ProfileResource>>(profilesByUser));
        }

    }
}