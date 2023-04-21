using HotChocolate.Types;
using MTask.Boilerplate.Api.DataLoaders;
using MTask.Boilerplate.Core.People;
using MTask.Extensions.HotChocolate;

namespace MTask.Boilerplate.Api.Schema.Persons
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Name("Person");

            descriptor
                .ImplementsNode()
                .IdField(p => p.Id)
                .ResolveNodeWith<PersonByIdsDataLoader>(p => p.LoadAsync(default(int), default));

            //descriptor.UseDatabaseId(p => p.Id);

            descriptor.Field(p => p.EyeColor);
            descriptor.Field(p => p.BirthYear);
            descriptor.Field(p => p.Gender);
            descriptor.Field(p => p.HairColor);
            descriptor.Field(p => p.Height);
            descriptor.Field(p => p.Mass);
            descriptor.Field(p => p.Name);
            descriptor.Field(p => p.SkinColor);
            descriptor.Field(p => p.Created);
            descriptor.Field(p => p.LastEdited);
        }
    }
}
