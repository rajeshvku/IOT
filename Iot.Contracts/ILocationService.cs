using System.Collections.Generic;
using System.Threading.Tasks;
using Iot.Dto;

namespace Iot.Contracts
{
    public interface ILocationService
    {
        Task<ReturnResponse<ResponseDetail>> AddCity(string region,int regionId);
        Task<ReturnResponse<ResponseDetail<List<MasterModel>>>> GetCities();
    }
}
