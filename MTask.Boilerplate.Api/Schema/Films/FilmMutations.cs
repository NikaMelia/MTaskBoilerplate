using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MTask.Boilerplate.Api.Schema.Utils;
using MTask.Boilerplate.Application.Films;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.Planets;

namespace MTask.Boilerplate.Api.Schema.Films
{
    [ExtendObjectType(typeof(Mutation))]
    public class FilmMutations
    {
        [Error(typeof(ResponseError))]
        public async Task<Film> CreateFilm([Service] IFilmService filmService,
            string title, int episodeId,
            string openingCrawl, string director,
            string producer, DateTime releaseDate)
        {
            return await filmService.Create(title, episodeId, openingCrawl, director, producer, releaseDate);
        }

        [Error(typeof(ResponseError))]
        public async Task<Film> UpdateFilm([Service] IFilmService filmService,
            [ID(nameof(Film))]int filmId,
            string title, int episodeId,
            string openingCrawl, string director,
            string producer, DateTime releaseDate)
        {
            return await filmService.Update(filmId, title, episodeId, openingCrawl, director, producer, releaseDate);
        }

        [Error(typeof(ResponseError))]
        public async Task<Film> AttachPlanetToFilm([Service] IFilmService filmService, [ID(nameof(Film))]int filmId, [ID(nameof(Planet))]int planetId)
        {
            return await filmService.AttachPlanetToFilm(filmId, planetId);
        }

        [Error(typeof(ResponseError))]
        public async Task<Film> DeleteFilm([ID(nameof(Film))]int filmId, [Service] IFilmService filmService)
        {
            return await filmService.DeleteById(filmId);
        }
        
    }
}
