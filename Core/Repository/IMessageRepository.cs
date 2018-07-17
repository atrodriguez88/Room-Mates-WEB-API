using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Core.Repository
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> GetMessage(int id);

        Task<List<Message>> GetMessagesForUser(MessageQuery queryObj);
        //        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}