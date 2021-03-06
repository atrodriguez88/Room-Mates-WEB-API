using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models.Auth;

namespace RoomM.API.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserController(IUserRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByEmail(string id)
        {
            var user = await repository.GetUserByEmail(id);
            if (user == null)
                NotFound();
            return Ok(mapper.Map<ApplicationUser, ApplicationUserResource>(user));
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await repository.GetUsers();
            if (users == null)
                NoContent();
            return Ok(mapper.Map<List<ApplicationUser>, List<ApplicationUserResource>>(users));
        }
    }
}