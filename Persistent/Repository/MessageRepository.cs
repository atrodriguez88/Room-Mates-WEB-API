using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Repository;
using RoomM.API.Persistent.Entity;

namespace RoomM.API.Persistent.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly RoomMDbContext context;

        public MessageRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Message> GetMessage(int userId)
        {
            return await context.Messages.SingleOrDefaultAsync(m => m.SenderMessId == userId);
        }
    }
}
