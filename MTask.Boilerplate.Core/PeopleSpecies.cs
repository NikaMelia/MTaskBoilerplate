using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Species;

namespace MTask.Boilerplate.Core;

public class PeopleSpecies
{
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
}