using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MTask.Boilerplate.Api.DataLoaders;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.Core.Planets;
using MTask.Extensions.Core.Errors;

namespace MTask.Boilerplate.Api.Schema.Planets
{
    [ExtendObjectType(typeof(Query))]
    public class PlanetQueries
    {
        public async Task<Planet> Planet([Service] PlanetByIdsDataLoader planetByIdsDataLoader, [ID] int id)
        {
            var planet = await planetByIdsDataLoader.LoadAsync(id);
            if (planet == null)
                throw new NotFoundMTOperationException(id);
            
            return planet;
        }
    }
}
