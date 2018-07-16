using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models.Domain;

namespace RoomM.API.Core.Repository
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> GetMessage(int userId);
        //        Task<IEnumerable<Message>> GetMessagesForUser();
        //        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);

    }
}