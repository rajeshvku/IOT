using System.Collections.Generic;
using System.Threading.Tasks;
using Iot.Dto;

namespace Iot.Contracts
{
    public interface ISiteService
    {
        Task<ReturnResponse<ResponseDetail>> AddSite(string region, int locationId);
        Task<ReturnResponse<ResponseDetail<List<MasterModel>>>> GetSites();
    }
}
