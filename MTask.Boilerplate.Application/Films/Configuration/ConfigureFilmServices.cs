using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Films.Configuration
{
    public static class ConfigureFilmServices
    {
        public static IServiceCollection AddFilmServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmService, FilmService>();

            return services;
        }

    }
}
