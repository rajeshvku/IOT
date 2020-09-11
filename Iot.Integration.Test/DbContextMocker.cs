using Iot.Database;
using Microsoft.EntityFrameworkCore;

namespace Iot.Integration.Test
{
    public static class DbContextMocker
    {
        public static IotContext GetIotContext()
        {
            var options = new DbContextOptionsBuilder<IotContext>()
                .UseSqlite($"Data Source=augmento.db")
                .Options;
            var context = new IotContext(options);
            context.Initilize();
            return context;
        }
    }
}
