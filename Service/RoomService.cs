﻿using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> GetRoom(int id);
        Task AddRoomAsync(Room room);
        void Remove(Room room);
        IEnumerable<Room> GetRoomsByUserId(int userId);
    }
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository repository;
        private readonly ILoggerManager logger;
        private readonly RoomMDbContext context;

        public RoomService(IRoomRepository repository, ILoggerManager logger, RoomMDbContext context)
        {
            this.repository = repository;
            this.logger = logger;
            this.context = context;
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
                var e = await repository.Include(r => r.PropertyType).SingleOrDefault(r => r.Id == id);
                return e;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            try
            {
                //x => x.PropertyType, x => x.Rules, x => x.PropertyFeatures, x => x.RoomFeatures
                return await repository.GetAll();
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
                return repository.Find(r => r.Id == userId);
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
    }
}