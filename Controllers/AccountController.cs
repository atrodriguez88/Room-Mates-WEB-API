using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models;

namespace RoomM.API.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly IMapper mapper;

        public AccountController(IAuthRepository repository, IMapper mapper )
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserInfoResource userInfo)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = userInfo.Email, Email = userInfo.Email
                                                , FirstName = userInfo.firstName, LastName = userInfo.lastName,
                                                AdTitle = userInfo.adTitle, AdDescription = userInfo.adDescription };
                var UserExist = await repository.UserExist(userInfo.Email);
                if (UserExist)
                {
                   return BadRequest("This user alraedy exist");
                }
                var result = await repository.Register(user, userInfo.Password);
                if (result)
                {                    
                    return Ok(repository.BuildToken(mapper.Map<UserInfoResource,UserInfo>(userInfo)));
                }
                else
                {
                    return BadRequest("Password invalid, You must use alphanumeric caracters, numbers and upper case");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserInfoResource userInfo)
        {
            if (ModelState.IsValid)
            {
                var UserExist = await repository.UserExist(userInfo.Email);
                if (UserExist)
                {
                    BadRequest("This user alraedy exist");
                }
                var result = await repository.Login(userInfo.Email, userInfo.Password);
                if (result)
                {
                    return Ok(repository.BuildToken(mapper.Map<UserInfoResource,UserInfo>(userInfo)));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }        
    }
}