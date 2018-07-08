using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core;
using RoomM.API.Core.Models.Auth;

namespace RoomM.API.Persistent
{
    public class UserRepository : IUserRepository
    {
        private readonly RoomMDbContext context;
        public UserRepository(RoomMDbContext context)
        {
            this.context = context;
        }
        public async Task<ApplicationUser> GetUser(string email)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}