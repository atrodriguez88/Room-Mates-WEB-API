using Microsoft.AspNetCore.Http;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models.Domain;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RoomM.API.Service
{
    public interface IPhotoService
    {
        Photo UploadPhoto(IFormFile file, IHostingEnvironment host);
    }
    public class PhotoService : IPhotoService
    {
        private readonly ILoggerManager logger;

        public PhotoService(ILoggerManager logger)
        {
            this.logger = logger;
        }
        public Photo UploadPhoto(IFormFile file, IHostingEnvironment host)
        {
            try
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
                    file.CopyToAsync(stream);
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
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return new Photo();
            }
        }
    }


}
