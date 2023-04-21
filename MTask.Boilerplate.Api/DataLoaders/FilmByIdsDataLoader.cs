using GreenDonut;
using MTask.Boilerplate.Application.Films;
using MTask.Boilerplate.Core.Films;

namespace MTask.Boilerplate.Api.DataLoaders
{
    public class FilmByIdsDataLoader : BatchDataLoader<int, Film>
    {
        private readonly IFilmService _filmService;

        public FilmByIdsDataLoader(
            IFilmService filmService,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null) : base(batchScheduler,options)
        {
            _filmService = filmService;
        }
        
        protected override async Task<IReadOnlyDictionary<int, Film>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var films = await _filmService.GetFilmsByIds(keys);

            return films.ToDictionary(f => f.Id);
        }
    }
}
