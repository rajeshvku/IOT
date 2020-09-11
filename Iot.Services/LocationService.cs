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
    public class LocationService:ILocationService
    {
        private readonly IotContext _context;

        public LocationService(IotContext context)
        {
            _context = context;
        }
        public async Task<ReturnResponse<ResponseDetail>> AddCity(string region,int regionId)
        {
            try
            {
                if (!await _context.Cities.AnyAsync(x => x.Name.ToLower() == region.ToLower()))
                {
                    if (await _context.Region.AnyAsync(x => x.Id == regionId))
                    {
                        await _context.Cities.AddAsync(new Cities
                        {
                            Name = region,
                            RegionId = regionId
                        });
                        if (await _context.SaveChangesAsync() == 1)
                        {
                            return GlobalReturnService.ResponseData(HttpStatusCode.OK, "Success",
                                true);
                        }
                        return GlobalReturnService.ResponseData(HttpStatusCode.InternalServerError, "Something Went Wrong, while updating entries",
                            false);
                    }
                    return GlobalReturnService.ResponseData(HttpStatusCode.NotFound, "Region Not Found",
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

        public async Task<ReturnResponse<ResponseDetail<List<MasterModel>>>> GetCities()
        {
            try
            {
                var regions = await _context.Cities.Select(x => new MasterModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                return GlobalReturnService.ResponseData<List<MasterModel>>(HttpStatusCode.OK, "success",
                    false, regions);
            }
            catch (Exception ex)
            {
                return GlobalReturnService.ResponseData<List<MasterModel>>(HttpStatusCode.InternalServerError, ex.Message,
                    false, null);
            }
            
            
        }
    }
}
