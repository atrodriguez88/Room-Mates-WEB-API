using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace RoomM.API.Service
{
    public interface IPhotoStorage
    {
        string StorePhoto(IFormFile file, IHostingEnvironment host);
    }

    public class FileSystemPhotoStore : IPhotoStorage
    {
        public string StorePhoto(IFormFile file, IHostingEnvironment host)
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
            return fileName;
        }
    }
}