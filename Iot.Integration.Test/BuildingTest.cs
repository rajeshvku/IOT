using Iot.Contracts;

namespace Iot.Integration.Test
{
    public class BuildingTest
    {
        private ILocationService _serives;

        public BuildingTest()
        {
            var dbContext = DbContextMocker.GetIotContext();
        }
    }
}
