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
    public class BuildingService: IBuildingService
    {
        private readonly IotContext _context;

        public BuildingService(IotContext context)
        {
            _context = context;
        }

        public async Task<ReturnResponse<ResponseDetail>> AddBuilding(string name, int siteId, string area)
        {
            try
            {
                if (!await _context.Buildings.AnyAsync(x => x.Name.ToLower() == name.ToLower()))
                {
                    if (await _context.Sites.AnyAsync(x => x.Id == siteId))
                    {
                        await _context.Buildings.AddAsync(new Building
                        {
                            Name = name,
                            Area = area,
                            SitesId = siteId

                        });
                        if (await _context.SaveChangesAsync() == 1)
                        {
                            return GlobalReturnService.ResponseData(HttpStatusCode.OK, "Success",
                                true);
                        }
                        return GlobalReturnService.ResponseData(HttpStatusCode.InternalServerError, "Something Went Wrong, while updating entries",
                            false);
                    }
                    return GlobalReturnService.ResponseData(HttpStatusCode.NotFound, "Site Not Found",
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

        public async Task<ReturnResponse<ResponseDetail>> AddTemperature(int buildingId, string temperature)
        {
            try
            {
                if (await _context.Buildings.AnyAsync(x => x.Id == buildingId))
                {
                    var buildingDetails = await _context.Buildings.FirstOrDefaultAsync(x => x.Id == buildingId);
                    if (buildingDetails != null)
                    {
                        buildingDetails.Temperature = temperature;
                        if (await _context.SaveChangesAsync() == 1)
                        {
                            return GlobalReturnService.ResponseData(HttpStatusCode.OK, "temperature Updated Successfully",
                                true);
                        }
                    }
                    return GlobalReturnService.ResponseData(HttpStatusCode.NotFound, "Something went wrong while fetching records",
                        false);
                }
                return GlobalReturnService.ResponseData(HttpStatusCode.NotFound, "Building Not Found",
                    false);
            }
            catch (Exception e)
            {
                return GlobalReturnService.ResponseData(HttpStatusCode.InternalServerError, "Something Went Wrong, please contact admin",
                    false);
            }
        }

        public async Task<ReturnResponse<ResponseDetail<string>>> GetTemperatureById(int buildingId)
        {
            try
            {
                if (await _context.Buildings.AnyAsync(x => x.Id == buildingId))
                {
                    var buildingDetails = await _context.Buildings.FirstOrDefaultAsync(x => x.Id == buildingId);
                    return GlobalReturnService.ResponseData<string>(HttpStatusCode.OK, "Success",
                        true, $"Temperature is :{buildingDetails.Temperature}");
                }
                return GlobalReturnService.ResponseData<string>(HttpStatusCode.NotFound, "Building Not Found",
                    false, "");
            }
            catch(Exception ex)
            {
                return GlobalReturnService.ResponseData<string>(HttpStatusCode.OK, "Something went wrong",
                    false, "");
            }
        }






        public async Task<ReturnResponse<ResponseDetail<string>>> GetTemperature(string region, string location, string site, string building)
        {
            try
            {
               
                if (await _context.Region.AnyAsync(x => x.Name.ToLower() == region.ToLower()))
                {

                    var regions = await _context.Region.FirstOrDefaultAsync(x => x.Name.ToLower() == region.ToLower());
                    
                    
                    if (await _context.Cities.AnyAsync(x =>
                        x.Name.ToLower() == location.ToLower() && x.RegionId == regions.Id))
                    {


                        var locations = await _context.Cities.FirstOrDefaultAsync(x =>
                            x.Name.ToLower() == location.ToLower() && x.RegionId == regions.Id);
                        
                        
                        if (await _context.Sites.AnyAsync(x =>
                            x.CitiesId == locations.Id && x.Name.ToLower() == site.ToLower()))
                        {

                            var sites = await _context.Sites.FirstOrDefaultAsync(x =>
                                x.CitiesId == locations.Id && x.Name.ToLower() == site.ToLower());


                            if (await _context.Buildings.AnyAsync(x =>
                                x.Name.ToLower() == building.ToLower() && x.SitesId == sites.Id))
                            {

                                var buildings = await _context.Buildings.FirstOrDefaultAsync(x =>
                                    x.Name.ToLower() == building.ToLower() && x.SitesId == sites.Id);

                                return GlobalReturnService.ResponseData<string>(HttpStatusCode.OK, "Success",
                                    true, $"building Name: {buildings.Name}, Area:{buildings.Area}, Temperature: {buildings.Temperature}");

                            }
                            return GlobalReturnService.ResponseData<string>(HttpStatusCode.NotFound, "building is not found",
                                false, "");

                        }
                        return GlobalReturnService.ResponseData<string>(HttpStatusCode.NotFound, "Site is not found",
                            false, "");

                    }
                    return GlobalReturnService.ResponseData<string>(HttpStatusCode.NotFound, "City is not found",
                        false, "");

                }
                return GlobalReturnService.ResponseData<string>(HttpStatusCode.NotFound, "Region Not Found",
                    false, "");

            }
            catch (Exception ex)
            {
                return GlobalReturnService.ResponseData<string>(HttpStatusCode.OK, "Something went wrong",
                    false, "");
            }
        }








        public async Task<ReturnResponse<ResponseDetail<List<BuildingDetails>>>> GetBuildings()
        {
            var regions = await _context.Buildings.Include(x=>x.Sites).Include(x=>x.Sites.Cities).Include(x=>x.Sites.Cities.Region).Select(x => new BuildingDetails
            {
                Region = x.Sites.Cities.Region.Name,
                Location = x.Sites.Cities.Name,
                Site = x.Sites.Name,
                Building = x.Name,
                Temperature = x.Temperature,
                Area = x.Area
            }).ToListAsync();
            return GlobalReturnService.ResponseData<List<BuildingDetails>>(HttpStatusCode.OK, "success",
                true, regions);
        }
    }
}
