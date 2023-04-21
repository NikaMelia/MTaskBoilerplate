using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Planets.Configuration
{
    public static class ConfigurePlanetServices
    {
        public static IServiceCollection AddPlanetServices(this IServiceCollection services)
        {
            services.AddScoped<IPlanetService, PlanetService>();

            return services;
        }
    }
}
