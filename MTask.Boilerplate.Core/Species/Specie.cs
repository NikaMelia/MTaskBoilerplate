using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;

namespace MTask.Boilerplate.Core.Species;

public class Specie
{
    public Specie(string name, string classification, string designation, string averageHeight, string averageLifespan, string eyeColor, string hairColor, string skinColor, string language)
    {
        Name = name;
        Classification = classification;
        Designation = designation;
        AverageHeight = averageHeight;
        AverageLifespan = averageLifespan;
        EyeColor = eyeColor;
        HairColor = hairColor;
        SkinColor = skinColor;
        Language = language;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Classification { get; set; }
    public string Designation { get; set; }
    public string AverageHeight { get; set; }
    public string AverageLifespan { get; set; }
    
    // A comma-separated string of common eye colors for this species, "none" if this species does not typically have eyes.
    public string EyeColor { get; set; }
    // A comma-separated string of common hair colors for this species, "none" if this species does not typically have hair.
    public string HairColor { get; set; }
    //  A comma-separated string of common skin colors for this species, "none" if this species does not typically have skin.
    public string SkinColor { get; set; }
    public string Language { get; set; }
    
    public Planet HomeWorld { get; set; } = null!;
    public List<Person> People { get; set; }  = null!;
    public List<Film> Films { get; set; } = null!;
    
    public DateTime Created { get; set; }
    public DateTime LastUpdateDate { get; set; }
}