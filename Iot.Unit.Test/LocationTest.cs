using System.Net.Http;
using System.Threading.Tasks;
using Iot.Api;
using Xunit;

namespace Iot.Unit.Test
{
    public class LocationTest: IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;

        public LocationTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }
        [Fact]
        public async Task GetLocations_Return_Success()
        {
            //Arrange
            var request = new
            {
                Url = "/api/Location/list"
            };
            //Act
            var response = await _client.GetAsync(request.Url);
            //Assert
            response.EnsureSuccessStatusCode();
        }
    }

}
