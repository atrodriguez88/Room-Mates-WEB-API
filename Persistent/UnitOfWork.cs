using System.Threading.Tasks;
using RoomM.API.Core;

namespace RoomM.API.Persistent
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoomMDbContext context;
        public UnitOfWork(RoomMDbContext context)
        {
            this.context = context;

        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}