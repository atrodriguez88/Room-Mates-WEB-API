using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Service;

namespace RoomM.API.Controllers
{
    [Route("/api/propertyfeatures")]
    public class PropertyFeatureController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPropertyFeaturesService service;
        public PropertyFeatureController(IPropertyFeaturesService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetPropertyFeatures()
        {
            var features = await service.GetPropertyFeatures();
            if (features == null)
                return NoContent();
            return Ok(mapper.Map<IEnumerable<PropertyFeatures>, IEnumerable<KeyValuePairResource>>(features));
        }
    }
}