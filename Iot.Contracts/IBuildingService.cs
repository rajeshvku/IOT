using System.Collections.Generic;
using System.Threading.Tasks;
using Iot.Dto;

namespace Iot.Contracts
{
    public interface IBuildingService
    {
        Task<ReturnResponse<ResponseDetail>> AddBuilding(string name, int siteId, string area);
        Task<ReturnResponse<ResponseDetail>> AddTemperature(int buildingId, string temperature);
        Task<ReturnResponse<ResponseDetail<string>>> GetTemperatureById(int buildingId);

        Task<ReturnResponse<ResponseDetail<string>>> GetTemperature(string region, string location, string site,
            string building);

        Task<ReturnResponse<ResponseDetail<List<BuildingDetails>>>> GetBuildings();
    }
}
