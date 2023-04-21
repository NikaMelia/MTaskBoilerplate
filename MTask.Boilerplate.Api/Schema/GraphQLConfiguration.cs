using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Execution.Configuration;
using MTask.Boilerplate.Api.DataLoaders;
using MTask.Boilerplate.Api.Schema.Films;
using MTask.Boilerplate.Api.Schema.Films.Configuration;
using MTask.Boilerplate.Api.Schema.Persons;
using MTask.Boilerplate.Api.Schema.Planets.Configuration;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.EFCore;
using MTask.Extensions.HotChocolate;

namespace MTask.Boilerplate.Api.Schema
{
    public static class GraphQLConfiguration
    {
        public static IServiceCollection AddBoilerGraphQl(this IServiceCollection services)
        {
            services
                .AddHttpResultSerializer<MTHttpResultSerializer>()
                .AddGraphQLServer()
                .RegisterDbContext<BoilerplateDbContext>()
                .AddGlobalObjectIdentification()
                .AddErrorFilter<MTHotChocolateErrorFilterMiddleware>()
                .AddFilmGraphQl()
                .AddPlanetGraphQl()
                .AddType<PersonType>()
                .RegisterService<IPlanetService>()
                .AddQueryType<Query>()
                .AddGraphQLDataLoaders()
                .AddMutationType<Mutation>()
                .AddMutationConventions();

            return services;
        }

        public static IRequestExecutorBuilder AddGraphQLDataLoaders(this IRequestExecutorBuilder builder)
        {
            builder
                .AddDataLoader<FilmByIdsDataLoader>()
                .AddDataLoader<PersonByIdsDataLoader>()
                .AddDataLoader<PlanetByIdsDataLoader>();

            return builder;
        }
    }
}
