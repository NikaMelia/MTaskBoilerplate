using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.Core.Species;
using MTask.Boilerplate.Core.Starships;
using MTask.Boilerplate.Core.Vehicles;
using MTask.Boilerplate.EFCore.EntityConfigurations;

namespace MTask.Boilerplate.EFCore;

public class BoilerplateDbContext : DbContext
{
    public BoilerplateDbContext(DbContextOptions<BoilerplateDbContext> options) : base(options)
    {
    }

    public DbSet<Film> Films => Set<Film>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<Planet> Planets => Set<Planet>();
    public DbSet<Specie> Species => Set<Specie>();
    public DbSet<StarShip> StarShips => Set<StarShip>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PlanetEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SpeciesEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StarShipEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleEntityConfiguration());
    }
}