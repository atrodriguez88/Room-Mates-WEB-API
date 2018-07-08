﻿using RoomM.API.Core;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Service
{
    public interface IProfileService
    {
        Task<Profile> GetProfile(int id);
        IEnumerable<Profile> GetProfileByUserId(int userId);
        Task<IEnumerable<Profile>> GetProfiles(FilterProfile filter);

        Task AddProfileAsync(Profile profile);
        void Remove(Profile profile);
        Task AddPhoto(int value, Photo photo);
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository repository;
        private readonly ILoggerManager logger;

        public ProfileService(IProfileRepository repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task AddProfileAsync(Profile profile)
        {
            try
            {
                await repository.Insert(profile);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }

        public async Task<Profile> GetProfile(int id)
        {
            try
            {
                var test =  await repository.GetProfile(id);
                return test;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public IEnumerable<Profile> GetProfileByUserId(int userId)
        {
            try
            {
                return repository.Find(p => p.Id == userId);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Profile>> GetProfiles(FilterProfile filter)
        {
            try
            {
                return await repository.GetProfiles(filter);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public void Remove(Profile profile)
        {
            try
            {
                repository.Delete(profile);
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
