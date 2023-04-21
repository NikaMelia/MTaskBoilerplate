using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Persons.Configuration
{
    public static class ConfigurePersonServices
    {
        public static IServiceCollection AddPersonServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
