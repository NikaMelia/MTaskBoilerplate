using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MTask.Boilerplate.Api.Schema.Utils;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.Core.Planets;

namespace MTask.Boilerplate.Api.Schema.Planets
{
    [ExtendObjectType(typeof(Mutation))]
    public class PlanetMutations
    {
        [Error(typeof(ResponseError))]
        public async Task<Planet> CreatePlanet([Service] IPlanetService planetService,
            string name, string diameter, string rotationPeriod,
            string orbitalPeriod, string gravity,
            string population, string climate,
            string terrain, string surfaceWater)
        {
            return await planetService.Create(
                name, diameter, rotationPeriod, 
                orbitalPeriod, gravity, population, 
                climate, terrain, surfaceWater);
        }

        [Error(typeof(ResponseError))]
        public async Task<Planet> UpdatePlanet([Service] IPlanetService planetService,
            [ID]int id, string name, string diameter, string rotationPeriond,
            string orbitalPeriod, string gravity, string population, string climate,
            string terrain, string surfaceWater)
        {
            return await planetService.Update(id, name, diameter, rotationPeriond, orbitalPeriod, gravity, population, climate, terrain, surfaceWater);
        }
    }
}
