using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLog;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Repository;

namespace RoomM.API.Service
{
    public interface IMessageService
    {
        Task<Message> GetMessage(int id);
        Task<List<Message>> GetMessagesForUser();
        Task AddMessageAsync(Message msg);
    }

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository repository;
        private readonly ILoggerManager logger;

        public MessageService(IMessageRepository repository, ILoggerManager logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<Message> GetMessage(int id)
        {
            try
            {
                return await repository.GetMessage(id);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public async Task AddMessageAsync(Message msg)
        {
            try
            {
                await repository.Insert(msg);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }

        public Task<List<Message>> GetMessagesForUser()
        {
            throw new NotImplementedException();
        }
    }
}