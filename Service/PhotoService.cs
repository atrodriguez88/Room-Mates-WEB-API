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
        private readonly IPhotoStorage photoStorage;

        public PhotoService(ILoggerManager logger, IPhotoStorage photoStorage)
        {
            this.logger = logger;
            this.photoStorage = photoStorage;
        }
        public Photo UploadPhoto(IFormFile file, IHostingEnvironment host)
        {
            try
            {
                var fileName = photoStorage.StorePhoto(file, host);

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
