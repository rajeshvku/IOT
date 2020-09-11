using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Iot.Database
{
    public static class IotContextConfigure
    {
        public static IServiceCollection IotConfigureService(this IServiceCollection collection)
        {
            collection.AddDbContext<IotContext>(options =>
            {
                options.UseSqlite("Data Source=augmento.db");
            });

            return collection;
        }
    }
}
