using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;

namespace RoomM.API.Controllers
{
    [Route("/api/propertype")]
    public class PropertyTypeController : Controller
    {
        private readonly IMapper mapper;
        private readonly PropertyTypeRepository repository;
        public PropertyTypeController(PropertyTypeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var types = await repository.GetPropertyTypes();
            if(types ==null)
                return NoContent();
            return Ok(mapper.Map<List<PropertyType>, List<KeyValuePairResource>>(types));
        }
    }
}