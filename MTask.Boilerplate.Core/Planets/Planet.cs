using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;

namespace MTask.Boilerplate.Core.Planets;

public class Planet
{
    public Planet(string name, string diameter, string rotationPeriod, string orbitalPeriod, string gravity, string population, string climate, string terrain, string surfaceWater)
    {
        Name = name;
        Diameter = diameter;
        RotationPeriod = rotationPeriod;
        OrbitalPeriod = orbitalPeriod;
        Gravity = gravity;
        Population = population;
        Climate = climate;
        Terrain = terrain;
        SurfaceWater = surfaceWater;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Diameter { get; set; }
    public string RotationPeriod { get; set; }
    public string OrbitalPeriod { get; set; }
    public string Gravity { get; set; }
    public string Population { get; set; }
    public string Climate { get; set; }
    public string Terrain { get; set; }
    public string SurfaceWater { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    
    public List<Person> Residents { get; set; } = null!;
    public List<Film> Films { get; set; } = null!;
}