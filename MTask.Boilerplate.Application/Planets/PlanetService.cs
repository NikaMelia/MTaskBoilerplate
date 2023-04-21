using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Application.ErrorHandling;
using MTask.Boilerplate.Application.Planets.Ordering;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.EFCore;
using MTask.Extensions.Core.Errors;
using MTask.Extensions.Core.Pagination;
using MTask.Extensions.Core.Pagination.Helpers;

namespace MTask.Boilerplate.Application.Planets
{
    public class PlanetService : IPlanetService
    {
        private readonly BoilerplateDbContext _dbContext;

        public PlanetService(BoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<Planet>> GetAllPlanets(PlanetOrder order, CursorPagingRequest cursorPagingRequest)
        {
            var planetsQueryable = PlanetsQueryable;

            planetsQueryable = order.Field switch
            {
                PlanetOrderField.Id => planetsQueryable.OrderByDirection(p => p.Id, order.Direction),
                PlanetOrderField.Name => planetsQueryable.OrderByDirection(p => p.Name, order.Direction),
                _ => throw new ArgumentOutOfRangeException()
            };

            return await planetsQueryable.ApplySlicingAsync(cursorPagingRequest);
        }

        public async Task<Planet> Create(
            string name, string diameter, string rotationPeriod, 
            string orbitalPeriod, string gravity, string population, 
            string climate, string terrain, string surfaceWater)
        {
            if (ExistWithName(name))
                throw new AlreadyExistMTOperationException();

            Planet planet = new Planet(name, diameter, rotationPeriod, orbitalPeriod, gravity, population, climate, terrain, surfaceWater);

            _dbContext.Planets.Add(planet);
            await _dbContext.SaveChangesAsync();

            return planet;
        }

        public async Task<List<Planet>> GetPlanetByIds(IReadOnlyList<int> keys)
        {
            var query = PlanetsQueryable.Where(p => keys.Contains(p.Id));

            return await query.ToListAsync();
        }

        private bool ExistWithName(string name)
        {
            return _dbContext.Planets.Any(p => p.Name == name);
        }

        public async Task<PaginationResult<Planet>> FilterPlanetsForFilm(
            int filmId, PlanetOrder order, CursorPagingRequest paginationRequest)
        {
            // we filter first 
            IQueryable<Planet> planets = PlanetsQueryable.Where(p => p.Films.Any(f => f.Id == filmId));

            // Apply order 
            planets = order.Field switch
            {
                PlanetOrderField.Name => planets.OrderByDirection(x => x.Name, order.Direction),
                PlanetOrderField.Id => planets.OrderByDirection(x => x.Id, order.Direction),
                _ => throw new ArgumentOutOfRangeException()
            };
            
            // Do Slice 
            var slicedPlanets = await planets.ApplySlicingAsync(paginationRequest);
            return slicedPlanets;
        }

        public async Task<Planet> GetFirstPlanetById(int planetId)
        {
            Planet? planet = await PlanetsQueryable.FirstOrDefaultAsync(p => p.Id == planetId);

            if (planet == null)
            {
                throw new NotFoundMTOperationException(planetId);
            }

            return planet;
        }

        public async Task<Planet> Update(
            int id, string name, string diameter, 
            string rotationPeriod, string orbitalPeriod, 
            string gravity, string population, string climate, 
            string terrain, string surfaceWater)
        {
            Planet planet = await GetFirstPlanetById(id);

            planet.Name = name;
            planet.Diameter = diameter;
            planet.RotationPeriod = rotationPeriod;
            planet.OrbitalPeriod = orbitalPeriod;
            planet.Gravity = gravity;
            planet.Population = population;
            planet.Climate = climate;
            planet.Terrain = terrain;
            planet.SurfaceWater = surfaceWater;

            await _dbContext.SaveChangesAsync();

            return planet;
        }

        private IQueryable<Planet> PlanetsQueryable { get { return _dbContext.Planets.Include(p => p.Residents); } }
    }
}
