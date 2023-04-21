using MTask.Boilerplate.Application.Films.Ordering;
using MTask.Boilerplate.Core.Films;
using MTask.Extensions.Core.Pagination.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Films
{
    public interface IFilmService
    {
        Task<PaginationResult<Film>> GetAllFilms(FilmOrder order, CursorPagingRequest cursorPagingRequest);
        Task<Film?> GetFilmByTitleWithCharacters(string title);
        Task<Film> Create(string title, int episodeId, string openingCrawl, string director, string producer, DateTime releaseDate);
        Task<Film> Update(int id, string title, int episodeId, string openingCrawl, string director, string producer, DateTime releaseDate);
        Task<List<Film>> GetFilmsByIds(IReadOnlyList<int> keys);
        Task<Film> AttachPlanetToFilm(int filmId, int planetId);
        Task<Film> DeleteById(int filmId);
    }
}
