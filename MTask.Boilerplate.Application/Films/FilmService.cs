using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Application.ErrorHandling;
using MTask.Boilerplate.Application.Films.Ordering;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.EFCore;
using MTask.Extensions.Core.Errors;
using MTask.Extensions.Core.Pagination;
using MTask.Extensions.Core.Pagination.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTask.Boilerplate.Application.Films
{
    public class FilmService : IFilmService
    {
        private readonly BoilerplateDbContext _dbContext;
        private readonly IPlanetService _planetService;

        public FilmService(BoilerplateDbContext dbContext, IPlanetService planetService)
        {
            _dbContext = dbContext;
            _planetService = planetService;
        }

        public async Task<Film> Create(string title, int episodeId, string openingCrawl, string director, string producer, DateTime releaseDate)
        {
            if(ExistWithTitle(title))
                throw new ResponseException("film.with.this.title.already.exist"); // for test exception

            Film film = new Film(title, episodeId, openingCrawl, director, producer, releaseDate);

            _dbContext.Films.Add(film);
            await _dbContext.SaveChangesAsync();

            return film;
        }

        private bool ExistWithTitle(string title)
        {
            return _dbContext.Films.Any(f => f.Title == title);
        }

        public async Task<PaginationResult<Film>> GetAllFilms(FilmOrder order, CursorPagingRequest cursorPagingRequest)
        {
            var filmsQueryable = FilmsQueryable;

            filmsQueryable = order.Field switch
            {
                FilmOrderField.Id => filmsQueryable.OrderByDirection(f => f.Id, order.Direction),
                FilmOrderField.Title => filmsQueryable.OrderByDirection(f => f.Title, order.Direction),
                _ => throw new ArgumentOutOfRangeException()
            };

            return await filmsQueryable.ApplySlicingAsync(cursorPagingRequest);
        }

        public async Task<Film?> GetFilmByTitleWithCharacters(string title)
        {
            return await _dbContext.Films.Include(m => m.Characters).FirstOrDefaultAsync(f => f.Title == title);
        }

        public async Task<List<Film>> GetFilmsByIds(IReadOnlyList<int> keys)
        {
            var query = FilmsQueryable.Where(f => keys.Contains(f.Id));

            return await query.ToListAsync();
        }

        public async Task<Film> DeleteById(int filmId)
        {
            var film = await GetFirstFilmById(filmId);
            
            _dbContext.Films.Remove(film);
            await _dbContext.SaveChangesAsync();
            return film;
        }

        /// <summary>
        /// Returns film by id or throws NotFound exception if film is not found  
        /// </summary>
        /// <returns></returns>
        public async Task<Film> GetFirstFilmById(int filmId)
        {
            Film? film = await FilmsQueryable.FirstOrDefaultAsync(f => f.Id == filmId);

            if (film == null)
            {
                throw new NotFoundMTOperationException(filmId);
            }

            return film;
        }

        public async Task<Film> Update(int id, string title, int episodeId, string openingCrawl, string director, string producer, DateTime releaseDate)
        {
            Film film = await GetFirstFilmById(id);

            film.Title = title;
            film.EpisodeId = episodeId;
            film.OpeningCrawl = openingCrawl;
            film.Director = director;
            film.Producer = producer;
            film.ReleaseDate = releaseDate;

            await _dbContext.SaveChangesAsync();

            return film;
        }

        public async Task<Film> AttachPlanetToFilm(int filmId, int planetId)
        {
            Film film = await GetFirstFilmById(filmId);

            if (film.Planets.Any(p => p.Id == planetId))
            {
                throw new AlreadyExistMTOperationException();
            }

            Planet planet = await _planetService.GetFirstPlanetById(planetId);

            film.Planets.Add(planet);
            await _dbContext.SaveChangesAsync();

            return film;
        }

        private IQueryable<Film> FilmsQueryable { get { return _dbContext.Films.Include(f => f.Planets).Include(f => f.Characters); } }
    }
}
