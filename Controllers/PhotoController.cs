using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                if (room == null)
                {
                    return NotFound();
                }
                if (file == null)
                {
                    BadRequest("Null File");
                }
                var photo = await CreateDirectAndCopyImage(file);
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
                var photo = await CreateDirectAndCopyImage(file);
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
        /// <summary>
        /// Procesando la imagen para directorio determinado
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<Photo> CreateDirectAndCopyImage(IFormFile file)
        {
            string uploadPath = Path.Combine(host.ContentRootPath, "UpLoad");   // C:\Users\ariel\source\repos\RoomM.App\RoomM.API\
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            /*
             * Create thumbnail image
             * A thumbnail image is a small version of an image.
             * You can create a thumbnail image by calling the GetThumbnailImage method of an Image object.
             * https://stackoverflow.com/questions/2808887/create-thumbnail-image
             */
            var photo = new Photo { FileName = fileName };
            return photo;
        }
    }
}