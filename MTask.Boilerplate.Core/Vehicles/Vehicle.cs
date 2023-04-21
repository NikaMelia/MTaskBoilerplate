using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;

namespace MTask.Boilerplate.Core.Vehicles;

public class Vehicle
{
    public Vehicle(string name, string model, string vehicleClass, string manufacturer, string length,
        string costInCredits, string crew, string passengers, string maxAtmospheringSpeed, string cargoCapacity,
        string consumables)
    {
        Name = name;
        Model = model;
        VehicleClass = vehicleClass;
        Manufacturer = manufacturer;
        Length = length;
        CostInCredits = costInCredits;
        Crew = crew;
        Passengers = passengers;
        MaxAtmospheringSpeed = maxAtmospheringSpeed;
        CargoCapacity = cargoCapacity;
        Consumables = consumables;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string VehicleClass { get; set; }
    public string Manufacturer { get; set; }
    public string Length { get; set; }
    public string CostInCredits { get; set; }
    //The number of personnel needed to run or pilot this vehicle
    public string Crew { get; set; }
    //The number of non-essential people this vehicle can transport
    public string Passengers { get; set; }
    public string MaxAtmospheringSpeed { get; set; }
    public string CargoCapacity { get; set; }
    //The maximum length of time that this vehicle can provide consumables for its entire crew without having to resupply
    public string Consumables { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastEdited { get; set; }

    public List<Film> Films { get; set; } = null!;
    public List<Person> Pilots { get; set; } = null!;
}