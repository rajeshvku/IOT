using Iot.Database;
using Microsoft.EntityFrameworkCore;

namespace Iot.Integration.Test
{
    public static class DbContextExtension
    {
        public static void Initilize(this IotContext _context)
        {
            _context.Database.Migrate();
            _context.Database.EnsureCreated();
        }
    }
}
