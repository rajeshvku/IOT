using Iot.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Iot.Database
{
    public class IotContext:DbContext
    {
        public IotContext(DbContextOptions<IotContext> options) : base(options)
        {

        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Sites> Sites { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Region> Region { get; set; }
    }
}
