using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Common.Constants;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;
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

        public async Task<Message> GetMessage(int id)
        {
            return await context.Messages.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Message>> GetMessagesForUser(MessageQuery queryObj)
        {
            var query = context.Messages.Include(m => m.SenderMess)
                                            .ThenInclude(p => p.Photos)
                                        .Include(m => m.SenderMess).ThenInclude(p => p.Photos)
                                        .AsQueryable();

            switch (queryObj.MessageSatus.ToLower())
            {
                case MessageState.Inbox:
                    query = query.Where(m => m.RecivedMessId == queryObj.UserId);
                    break;

                case MessageState.Outbox:
                    query = query.Where(m => m.SenderMessId == queryObj.UserId);
                    break;

                default:
                    query = query.Where(m => m.RecivedMessId == queryObj.UserId && m.IsRead == false);
                    break;
            }

            return await query.OrderByDescending(m => m.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await context.Messages.Include(m => m.SenderMess)
                                            .ThenInclude(p => p.Photos)
                                        .Include(m => m.SenderMess).ThenInclude(p => p.Photos)
                                        .Where(m => m.RecivedMessId == userId && m.SenderMessId == recipientId
                                        || m.RecivedMessId == recipientId && m.SenderMessId == userId)
                                        .OrderByDescending(m => m.DateSend)
                                        .ToListAsync();
            return messages;
        }
    }
}