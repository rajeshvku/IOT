using System.Collections.Generic;
using System.Threading.Tasks;
using Iot.Dto;

namespace Iot.Contracts
{
    public interface IRegionService
    {
        Task<ReturnResponse<ResponseDetail>> AddRegion(string region);
        Task<ReturnResponse<ResponseDetail<List<MasterModel>>>> GetRegions();
    }
}
