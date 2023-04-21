using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;
using MTask.Boilerplate.Core.Species;
using MTask.Boilerplate.Core.Starships;
using MTask.Boilerplate.Core.Vehicles;

namespace MTask.Boilerplate.Core.Films;

public class Film
{
    public Film(string title, int episodeId, string openingCrawl, string director, string producer, DateTime releaseDate)
    {
        Title = title;
        EpisodeId = episodeId;
        OpeningCrawl = openingCrawl;
        Director = director;
        Producer = producer;
        ReleaseDate = releaseDate;
    }

    public int Id { get; set; }
    public string Title { get; set; } 
    public int EpisodeId { get; set; }
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Vehicle> Vehicles { get; set; } = null!;
    public List<StarShip> StarShips { get; set; } = null!;
    public List<Specie> Species { get; set; } = null!;
    public List<Person> Characters { get; set; } = null!;
    public List<Planet> Planets { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastEdited { get; set; }
}