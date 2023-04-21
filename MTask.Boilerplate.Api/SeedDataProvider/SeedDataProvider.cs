using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.Core.Species;
using MTask.Boilerplate.Core.Starships;
using MTask.Boilerplate.Core.Vehicles;
using MTask.Boilerplate.EFCore.Seeder;
using Newtonsoft.Json;

namespace MTask.Boilerplate.Api.DataProvider;

public class SeedDataProvider : ISeedDataProvider
{

    public const string FileName = "seed.json";
    
    public List<Person> GetPeopleData()
    {
        var data = File.ReadAllText("seed.json");
        var film= JsonConvert.DeserializeObject<Film>(data);
        return film.Characters;
    }

    public List<Film> GetFilmsData()
    {
        var data = File.ReadAllText("seed.json");
        var film= JsonConvert.DeserializeObject<Film>(data);
        return new() {film};
    }

    public List<Planet> GetPlanetsData()
    {
        var data = File.ReadAllText("seed.json");
        var film= JsonConvert.DeserializeObject<Film>(data);
        return film.Planets;
    }

    public List<Specie> GetSpeciesData()
    {
        var data = File.ReadAllText("seed.json");
        var film= JsonConvert.DeserializeObject<Film>(data);
        return film.Species;
    }

    public List<StarShip> GetStarShipsData()
    {
        var data = File.ReadAllText("seed.json");
        var film= JsonConvert.DeserializeObject<Film>(data);
        return film.StarShips;
    }

    public List<Vehicle> GetVehiclesData()
    {
        var data = File.ReadAllText("seed.json");
        var film= JsonConvert.DeserializeObject<Film>(data);
        return film.Vehicles;
    }
}