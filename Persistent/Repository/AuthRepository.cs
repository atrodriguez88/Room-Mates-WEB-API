using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RoomM.API.Core;
using RoomM.API.Core.Models.Auth;

namespace RoomM.API.Persistent.Repository
{
    public class AuthRepository : IAuthRepository
    {        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoomMDbContext context;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AuthRepository(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              RoomMDbContext context)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            
        }

        public object BuildToken(ApplicationUser userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("Id", userInfo.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Llave_super_secreta"])); // environment variable
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Llave_super_secreta")); // environment variable            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = expiration};

        }

        public async Task<bool> Login(string user, string password)
        {
            var result = await signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> Register(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> UserExist(string user)
        {
            var result = await context.Users.SingleOrDefaultAsync(u => u.UserName == user);
            if(result != null)
                return true;
            return false;    
        }        
    }
}