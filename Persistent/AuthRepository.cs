using System.Threading.Tasks;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class AuthRepository : IAuthRepository
    {
        private readonly RoomMDbContext context;
        public AuthRepository(RoomMDbContext context)
        {
            this.context = context;
            
        }
        public Task Login(string user, string pass)
        {
            throw new System.NotImplementedException();
        }

        public Task Register(ApplicationUser user, string pass)
        {
            throw new System.NotImplementedException();
        }

        public bool UserExist(string user)
        {
            throw new System.NotImplementedException();
        }
    }
}