using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;

namespace RoomM.API.Controllers
{
    [Route("/api/rules")]
    public class RuleController : Controller
    {
        private readonly RoomMDbContext context;
        private readonly IMapper mapper;
        private readonly IRuleRepository repository;
        public RuleController(RoomMDbContext context, IMapper mapper, IRuleRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet()]
        public async Task<IActionResult> GetRules()
        {
            var rules = await repository.GetRules();

            if(rules == null)
                return NoContent();
            return Ok(mapper.Map<List<PropertyRules>, List<KeyValuePairResource>>(rules));
        }
    }
}