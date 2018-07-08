using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RoomM.API.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Common.Helpers
{
    public static class PhotoHelp
    {
        /// <summary>
        /// Procesando la imagen para directorio determinado
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<Photo> CreateDirectAndCopyImage(IFormFile file, IHostingEnvironment host)
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
