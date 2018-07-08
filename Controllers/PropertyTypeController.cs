using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/propertype")]
    public class PropertyTypeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPropertyTypeService service;
        public PropertyTypeController(IPropertyTypeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var types = await service.GetPropertyTypes();
            if(types ==null)
                return NoContent();
            return Ok(mapper.Map<IEnumerable<PropertyType>, IEnumerable<KeyValuePairResource>>(types));
        }
    }
}