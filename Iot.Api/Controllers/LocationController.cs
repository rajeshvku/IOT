using System.Threading.Tasks;
using Iot.Contracts;
using Iot.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class LocationController : BaseController
    {
        private readonly ILocationService _location;

        public LocationController(ILocationService location)
        {
            _location = location;
        }
        /// <summary>
        /// Need to pass location Details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "region": "India",
        ///        "location": "Bengaluru",
        ///        "site": "Eco Space",
        ///        "building": "Alpha"
        ///     }
        ///
        /// </remarks>
        /// <param name="location"></param>
        /// <returns>returns a success full message</returns>
        [HttpPost("Location")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddLocation(AddLocationDto location)
        {
            return SetResponse(await _location.AddCity(location.LocationName, location.RegionId));
        }
        [HttpGet("list")]
        public async Task<IActionResult> LocationList()
        {
            return SetResponse(await _location.GetCities());
        }
    }
}
