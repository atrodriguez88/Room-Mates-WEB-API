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
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/rules")]
    public class RuleController : Controller
    {
        private readonly RoomMDbContext context;
        private readonly IMapper mapper;
        private readonly IRuleService service;
        public RuleController(RoomMDbContext context, IMapper mapper, IRuleService service)
        {
            this.service = service;
            this.mapper = mapper;
            this.context = context;
        }
        [HttpGet()]
        public async Task<IActionResult> GetRules()
        {
            var rules = await service.GetRules();

            if(rules == null)
                return NoContent();
            return Ok(mapper.Map<IEnumerable<PropertyRules>, IEnumerable<KeyValuePairResource>>(rules));
        }
    }
}