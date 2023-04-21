using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.Core.Species;
using MTask.Boilerplate.Core.Starships;
using MTask.Boilerplate.Core.Vehicles;

namespace MTask.Boilerplate.Core.People;

public class Person
{
    public Person(EyeColors eyeColor, string birthYear, Gender gender, HairColor hairColor, string height, string mass, string name, string skinColor)
    {
        EyeColor = eyeColor;
        BirthYear = birthYear;
        Gender = gender;
        HairColor = hairColor;
        Height = height;
        Mass = mass;
        Name = name;
        SkinColor = skinColor;
    }

    public int Id { get; set; }
    public EyeColors EyeColor { get; set; }
    public string BirthYear { get; set; }
    public Gender Gender { get; set; }
    public HairColor HairColor { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string Name { get; set; }
    public string SkinColor { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastEdited { get; set; }

    public Planet HomeWorld { get; set; } = null!;
    public List<Film> Films { get; set; } = null!;
    public List<Specie> Species { get; set; } = null!;
    public List<StarShip> StarShips { get; set; } = null!;
    public List<Vehicle> Vehicles  { get; set; } = null!;
}