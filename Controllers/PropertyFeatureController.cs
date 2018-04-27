using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;

namespace RoomM.API.Controllers
{
    [Route("/api/propertyfeatures")]
    public class PropertyFeatureController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPropertyFeature repository;
        public PropertyFeatureController(IPropertyFeature repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetPropertyFeatures()
        {
            var features = await repository.GetPropertyFeatures();
            if (features == null)
                return NoContent();
            return Ok(mapper.Map<List<PropertyFeatures>, List<KeyValuePairResource>>(features));
        }
    }
}