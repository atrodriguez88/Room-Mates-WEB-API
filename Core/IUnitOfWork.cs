using System;
using System.Threading.Tasks;

namespace RoomM.API.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
        Task CompleteAsync();
    }
}