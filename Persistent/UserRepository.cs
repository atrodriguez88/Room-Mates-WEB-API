using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Persistent
{
    public class UserRepository : IUserRepository
    {
        private readonly RoomMDbContext context;
        public UserRepository(RoomMDbContext context)
        {
            this.context = context;
        }
        public async Task<ApplicationUser> GetUser(int id)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id.ToString());
            return user;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}