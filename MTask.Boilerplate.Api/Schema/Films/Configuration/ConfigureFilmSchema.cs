using HotChocolate.Execution.Configuration;

namespace MTask.Boilerplate.Api.Schema.Films.Configuration
{
    public static class ConfigureFilmSchema
    {
        public static IRequestExecutorBuilder AddFilmGraphQl(this IRequestExecutorBuilder builder)
        {
            builder
                .AddType<FilmType>()
                .AddType<FilmQueryType>()
                .AddTypeExtension<FilmQueries>()
                .AddTypeExtension<FilmMutations>();

            return builder;
        }
    }
}
