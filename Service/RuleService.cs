﻿using RoomM.API.Core;
using RoomM.API.Core.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models.Domain;

namespace RoomM.API.Service
{
    public interface IRuleService
    {
        Task<IEnumerable<PropertyRules>> GetRules();
    }
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository repository;
        private readonly ILoggerManager logger;
        public RuleService(IRuleRepository repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<IEnumerable<PropertyRules>> GetRules()
        {
            try
            {
                return await repository.GetAll();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }
    }
}
