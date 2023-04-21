using MTask.Boilerplate.Core.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTask.Boilerplate.Application.Planets.Ordering;
using MTask.Extensions.Core.Pagination;
using MTask.Extensions.Core.Pagination.Helpers;

namespace MTask.Boilerplate.Application.Planets
{
    public interface IPlanetService
    {
        Task<PaginationResult<Planet>> GetAllPlanets(PlanetOrder order, CursorPagingRequest cursorPagingRequest);
        Task<List<Planet>> GetPlanetByIds(IReadOnlyList<int> keys);
        Task<Planet> GetFirstPlanetById(int planetId);
        Task<Planet> Create(
            string name, string diameter, string rotationPeriod,
            string orbitalPeriod, string gravity,
            string population, string climate,
            string terrain, string surfaceWater);
        Task<Planet> Update(
            int id, string name, string diameter, 
            string rotationPeriod, string orbitalPeriod, 
            string gravity, string population, string climate, 
            string terrain, string surfaceWater);

        Task<PaginationResult<Planet>> FilterPlanetsForFilm(int filmId, PlanetOrder order,
            CursorPagingRequest paginationRequest);
    }
}
