using HotChocolate.Execution.Configuration;
using MTask.Boilerplate.Api.Schema.Films;
using MTask.Boilerplate.Core.Planets;

namespace MTask.Boilerplate.Api.Schema.Planets.Configuration
{
    public static class ConfigurePlanetSchema
    {
        public static IRequestExecutorBuilder AddPlanetGraphQl(this IRequestExecutorBuilder builder)
        {
            builder
                .AddType<PlanetType>()
                .AddType<PlanetQueryType>()
                .AddTypeExtension<PlanetQueries>()
                .AddTypeExtension<PlanetMutations>();

            return builder;
        }
    }
}
