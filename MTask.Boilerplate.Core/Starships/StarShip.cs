using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;

namespace MTask.Boilerplate.Core.Starships;

public class StarShip
{
    public StarShip(string name, string starshipClass, string manufacturer, string costInCredits, string length,
        string crew, string passengers, string maxAtmospheringSpeed, string hyperdriveRating, string mglt,
        string cargoCapacity, string consumables)
    {
        Name = name;
        StarshipClass = starshipClass;
        Manufacturer = manufacturer;
        CostInCredits = costInCredits;
        Length = length;
        Crew = crew;
        Passengers = passengers;
        MaxAtmospheringSpeed = maxAtmospheringSpeed;
        HyperdriveRating = hyperdriveRating;
        Mglt = mglt;
        CargoCapacity = cargoCapacity;
        Consumables = consumables;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string StarshipClass { get; set; }
    public string Manufacturer { get; set; }
    public string CostInCredits { get; set; }
    public string Length { get; set; }
    public string Crew { get; set; }
    public string Passengers { get; set; }
    public string MaxAtmospheringSpeed { get; set; }
    public string HyperdriveRating { get; set; }
    public string Mglt { get; set; }
    public string CargoCapacity { get; set; }
    public string Consumables { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastEdited { get; set; }

    public List<Film> Films { get; set; } = null!;
    public List<Person> Pilots { get; set; } = null!;
}