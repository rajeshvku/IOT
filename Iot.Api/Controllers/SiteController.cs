using System.Threading.Tasks;
using Iot.Contracts;
using Iot.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Iot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class SiteController : BaseController
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [HttpPost("AddSite")]
        public async Task<IActionResult> AddSite(AddSiteDto site)
        {
            return SetResponse(await _siteService.AddSite(site.SiteName, site.LocationId));
        }
        [HttpGet("list")]
        public async Task<IActionResult> LocationList()
        {
            return SetResponse(await _siteService.GetSites());
        }
    }
}
