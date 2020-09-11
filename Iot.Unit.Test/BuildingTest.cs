using System.Net.Http;
using Iot.Api;
using Xunit;

namespace Iot.Unit.Test
{
    public class BuildingTest: IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;

        public BuildingTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }
    }
}
