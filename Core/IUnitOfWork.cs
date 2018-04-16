using System.Threading.Tasks;

namespace RoomM.API.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}