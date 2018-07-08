using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/rules")]
    public class RuleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRuleService service;
        public RuleController(IMapper mapper, IRuleService service)
        {
            this.service = service;
            this.mapper = mapper;
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