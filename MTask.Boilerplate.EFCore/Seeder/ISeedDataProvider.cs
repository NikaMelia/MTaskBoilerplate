using System.Text.Json.Nodes;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.Core.Species;
using MTask.Boilerplate.Core.Starships;
using MTask.Boilerplate.Core.Vehicles;

namespace MTask.Boilerplate.EFCore.Seeder;

public interface ISeedDataProvider
{
    public List<Person> GetPeopleData();
    public List<Film> GetFilmsData();
    public List<Planet> GetPlanetsData();
    public List<Specie> GetSpeciesData();
    public List<StarShip> GetStarShipsData();
    public List<Vehicle> GetVehiclesData();
}

