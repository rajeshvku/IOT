using Iot.Contracts;
using Iot.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Iot.Domain
{
    public static class DomainExtensionService
    {
        //Depndency Inversion Principle
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IRegionService,RegionService>();
            services.AddScoped<ILocationService,LocationService>();
            services.AddScoped<ISiteService,SiteService>();
            services.AddScoped<IBuildingService,BuildingService>();
            return services;
        }
    }
}
