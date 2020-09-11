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
    public class SiteService: ISiteService
    {
        private readonly IotContext _context;

        public SiteService(IotContext context)
        {
            _context = context;
        }

        public async Task<ReturnResponse<ResponseDetail>> AddSite(string region, int locationId)
        {
            try
            {
                if (!await _context.Sites.AnyAsync(x => x.Name.ToLower() == region.ToLower()))
                {
                    if (await _context.Cities.AnyAsync(x => x.Id == locationId))
                    {
                        await _context.Sites.AddAsync(new Sites
                        {
                            Name = region,
                            CitiesId = locationId
                        });
                        if (await _context.SaveChangesAsync() == 1)
                        {
                            return GlobalReturnService.ResponseData(HttpStatusCode.OK, "Success",
                                true);
                        }
                        return GlobalReturnService.ResponseData(HttpStatusCode.InternalServerError, "Something Went Wrong, while updating entries",
                            false);
                    }
                    return GlobalReturnService.ResponseData(HttpStatusCode.NotFound, "Location Not Found",
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

        public async Task<ReturnResponse<ResponseDetail<List<MasterModel>>>> GetSites()
        {
            var regions = await _context.Sites.Select(x => new MasterModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return GlobalReturnService.ResponseData<List<MasterModel>>(HttpStatusCode.OK, "success",
                false, regions);
        }
    }
}
