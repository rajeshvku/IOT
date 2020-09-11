using System.Threading.Tasks;
using Iot.Contracts;
using Iot.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Iot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class BuildingController : BaseController
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        [HttpPost("Building")]
        public async Task<IActionResult> AddBuilding(AddBuildingDto building)
        {
            return SetResponse(
                await _buildingService.AddBuilding(building.BuildingName, building.SiteId, building.AreaName));
        }
        [HttpPost("BuildingTemperature")]
        public async Task<IActionResult> AddTemperature(AddBuildingTemperature temperature)
        {
            return SetResponse(
                await _buildingService.AddTemperature(temperature.BuildingId,temperature.Temperature));
        }
        [HttpGet("GetBuildingTemperatureById")]
        public async Task<IActionResult> GetTemperatureById(int buildingId)
        {
            return SetResponse(
                await _buildingService.GetTemperatureById(buildingId));
        }

        /// <summary>
        ///  Get Temperature
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
        /// <param name="buildingInfo"></param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("GetBuildingTemperature")]
        public async Task<IActionResult> GetTemperature(BuildingTemperature buildingInfo)
        {
            return SetResponse(
                await _buildingService.GetTemperature(buildingInfo.Region, buildingInfo.Location, buildingInfo.Site,
                    buildingInfo.Building));
        }
        [HttpGet("GetBuildingTemperatureList")]
        public async Task<IActionResult> GetTemperatureList()
        {
            return SetResponse(
                await _buildingService.GetBuildings());
        }
    }
}
