using System.Threading.Tasks;
using Iot.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Iot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class RegionController : BaseController
    {
        private readonly IRegionService _region;

        public RegionController(IRegionService region)
        {
            _region = region;
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> AddRegion(string name)
        {
            return SetResponse(await _region.AddRegion(name));
        }
        [HttpGet("list")]
        public async Task<IActionResult> RegionList()
        {
            return SetResponse(await _region.GetRegions());
        }
    }
}
