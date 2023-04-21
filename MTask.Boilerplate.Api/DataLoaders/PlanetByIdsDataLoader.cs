using GreenDonut;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.Core.Planets;

namespace MTask.Boilerplate.Api.DataLoaders
{
    public class PlanetByIdsDataLoader : BatchDataLoader<int, Planet>
    {
        private readonly IPlanetService _planetService;

        public PlanetByIdsDataLoader(
            IPlanetService planetService,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null) : base(batchScheduler,options)
        {
            _planetService= planetService;
        }

        protected override async Task<IReadOnlyDictionary<int, Planet>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var planets = await _planetService.GetPlanetByIds(keys);

            return planets.ToDictionary(p => p.Id);
        }
    }
}
