using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Persistent;

namespace RoomM.API.Controllers
{
    [Route("/api/rules")]
    public class RuleController : Controller
    {
        private readonly RoomMDbContext context;
        public RuleController(RoomMDbContext context)
        {
            this.context = context;
        }
        [HttpGet()]
        public async Task<IActionResult> GetRules()
        {
            var rules = await context.PropertyRules.ToListAsync();
            return Ok(rules);
        }
    }
}