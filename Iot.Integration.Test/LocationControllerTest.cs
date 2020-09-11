using System;
using System.Threading.Tasks;
using Iot.Api.Controllers;
using Iot.Contracts;
using Iot.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Iot.Integration.Test
{
    public class LocationControllerTest
    {
        private ILocationService _services;

        public LocationControllerTest()
        {
            //Arrange
            var dbContext = DbContextMocker.GetIotContext();
            _services = new LocationService(dbContext);
        }
        [Fact]
        public async Task GetLocations_Return_Success()
        {
            var controller = new LocationController(_services);
            //Act
            var response = await controller.LocationList() as ObjectResult;
            Assert.Equal(Convert.ToString(response.StatusCode),$"200");
        }
        
    }
}
