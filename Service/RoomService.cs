﻿using RoomM.API.Core.Log;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.QueryString;
using RoomM.API.Core.Repository;

namespace RoomM.API.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRooms(RoomQuery roomQuery);
        Task<Room> GetRoom(int id);
        Task AddRoomAsync(Room room);
        void Remove(Room room);
        IEnumerable<Room> GetRoomsByUserId(int userId);
        Task AddPhoto(int id, Photo photo);
    }
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository repository;
        private readonly ILoggerManager logger;

        public RoomService(IRoomRepository repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task AddRoomAsync(Room room)
        {
            try
            {
                await repository.Insert(room);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<Room> GetRoom(int id)
        {
            try
            {
                var e = await repository.GetRoom(id);
                return e;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Room>> GetRooms(RoomQuery roomQuery)
        {
            try
            {
                return await repository.GetRooms(roomQuery);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public IEnumerable<Room> GetRoomsByUserId(int userId)
        {
            try
            {
                return repository.Find(r => r.UserId == userId);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public void Remove(Room room)
        {
            try
            {
                repository.Delete(room);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }

        public async Task AddPhoto(int id, Photo photo)
        {
            try
            {
                await repository.AddPhoto(id, photo);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }
    }
}
