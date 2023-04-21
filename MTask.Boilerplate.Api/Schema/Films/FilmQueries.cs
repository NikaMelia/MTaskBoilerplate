using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Api.DataLoaders;
using MTask.Boilerplate.Application.Films;
using MTask.Boilerplate.Core.Films;

namespace MTask.Boilerplate.Api.Schema.Films
{
    [ExtendObjectType(typeof(Query))]
    public class FilmQueries
    {
        public async Task<Film> Film([Service] FilmByIdsDataLoader filmByIdDataLoader, [ID] int id)
        {
            var filmById = await filmByIdDataLoader.LoadAsync(id);
            return await filmByIdDataLoader.LoadAsync(id);
        }
    }
}
