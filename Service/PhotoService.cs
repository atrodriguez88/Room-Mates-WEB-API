using RoomM.API.Core.Log;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Service
{
    public interface IPhotoService
    {
        // Task AddPhoto(Photo photo);
    }
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository repository;
        private readonly ILoggerManager logger;

        public PhotoService(IPhotoRepository repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        //public async Task AddPhoto(Photo photo)
        //{
        //    try
        //    {
        //        await repository.Insert(photo);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError(e.Message);
        //    }
        //}
    }


}
