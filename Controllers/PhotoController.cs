using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Common.Helpers;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("api/rooms/{roomId}/[controller]")]
    [Route("api/profiles/{profileId}/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IHostingEnvironment host;
        private readonly IRoomService roomService;
        private readonly IProfileService profileService;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly int MAX_BYTES = 5 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILE_TYPE = { ".jpg", ".jpge", ".png"};

        public PhotoController(IHostingEnvironment host, IRoomService roomService, IProfileService profileService, IUnitOfWork uow, IMapper mapper)
        {
            this.host = host;            
            this.roomService = roomService;            
            this.profileService = profileService;
            this.uow = uow;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Upload(int? roomId, int? profileId, IFormFile file) // If I want many files use IFormFileCollection
        {
            //host.IsDevelopment()    // Check if it is devoloment for crate other Directory for test

            if (roomId.HasValue)
            {
                // Code upload photo room
                var room = await roomService.GetRoom(roomId.Value);

                if (room == null) return NotFound();
                if (file == null) return BadRequest("Null File");
                if (file.Length == 0) return BadRequest("Empty File");
                if (file.Length > MAX_BYTES) return BadRequest("Max file size exceeded");
                if (ACCEPTED_FILE_TYPE.Any( a => a == Path.GetExtension(file.FileName).ToLower())) return BadRequest("Invalid file type");

                var photo = await PhotoHelp.CreateDirectAndCopyImage(file, host);
                await roomService.AddPhoto(roomId.Value, photo);
                await uow.CompleteAsync();

                var photoResource = mapper.Map<Photo, PhotoResource>(photo);
                return Ok(photoResource);
            }
            else if (profileId.HasValue)
            {
                // Code upload photo profile
                var profile = await profileService.GetProfile(profileId.Value);
                if (profile == null)
                {
                    return NotFound();
                }
                var photo = await PhotoHelp.CreateDirectAndCopyImage(file, host);
                await profileService.AddPhoto(profileId.Value, photo);
                await uow.CompleteAsync();

                var photoResource = mapper.Map<Photo, PhotoResource>(photo);
                return Ok(photoResource);
            }
            else
            {
                return NotFound();
            }          
            
        }
    }
}