using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Iot.Contracts;
using Iot.Database;
using Iot.Dto;
using Iot.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Iot.Services
{
    public class RegionService: IRegionService
    {
        private readonly IotContext _context;

        public RegionService(IotContext context)
        {
            _context = context;
        }

        public async Task<ReturnResponse<ResponseDetail>> AddRegion(string region)
        {
            try
            {
                if (!await _context.Region.AnyAsync(x => x.Name.ToLower() == region.ToLower()))
                {
                    await _context.Region.AddAsync(new Region
                    {
                        Name = region
                    });
                    if (await _context.SaveChangesAsync() == 1)
                    {
                        return GlobalReturnService.ResponseData(HttpStatusCode.OK, "Success",
                            true);
                    }
                    return GlobalReturnService.ResponseData(HttpStatusCode.InternalServerError, "Something Went Wrong, while updating entries",
                        false);
                }
                else
                {
                    return GlobalReturnService.ResponseData(HttpStatusCode.Conflict, "region already Exist",
                        false);
                }
            }
            catch (Exception e)
            {
                return GlobalReturnService.ResponseData(HttpStatusCode.InternalServerError, "Something Went Wrong, please contact admin",
                    false);
            }
           
        }

        public async Task<ReturnResponse<ResponseDetail<List<MasterModel>>>> GetRegions()
        {
            var regions = await _context.Region.Select(x=> new MasterModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return GlobalReturnService.ResponseData<List<MasterModel>>(HttpStatusCode.OK, "success",
                false, regions);
        }

    }
}
