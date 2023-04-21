using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using MTask.Boilerplate.Api.DataLoaders;
using MTask.Boilerplate.Api.Schema.Persons;
using MTask.Boilerplate.Application.Persons;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;
using MTask.Extensions.HotChocolate;

namespace MTask.Boilerplate.Api.Schema.Planets
{
    public class PlanetType : ObjectType<Planet>
    {
        protected override void Configure(IObjectTypeDescriptor<Planet> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Name("Planet");

            descriptor
                .ImplementsNode()
                .IdField(p => p.Id)
                .ResolveNodeWith<PlanetByIdsDataLoader>(p => p.LoadAsync(default(int), default));

            descriptor.UseDatabaseId(p => p.Id);

            descriptor
                .Field(p => p.Residents)
                .UsePaging<PersonType>()
                .Resolve(context =>
                {
                    IEnumerable<Person> people = new List<Person>();

                    var edges = people.Select(person => new Edge<Person>(person, person.Id.ToString()))
                        .ToList();
                    var pageInfo = new ConnectionPageInfo(false, false, null, null);

                    var connection = new Connection<Person>(edges, pageInfo,
                        ct => ValueTask.FromResult(0));

                    return connection;
                });

            descriptor.Field(p => p.Id);
            descriptor.Field(p => p.Name);
            descriptor.Field(p => p.Diameter);
            // descriptor.Field(p => p.RotationPeriod);
            // descriptor.Field(p => p.OrbitalPeriod);
            // descriptor.Field(p => p.Gravity);
            // descriptor.Field(p => p.Population);
            // descriptor.Field(p => p.Climate);
            // descriptor.Field(p => p.Terrain);
            // descriptor.Field(p => p.SurfaceWater);
            // descriptor.Field(p => p.Created);
            // descriptor.Field(p => p.Edited);
        }
    }
}
