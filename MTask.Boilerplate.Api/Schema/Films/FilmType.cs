using System.Diagnostics;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Api.DataLoaders;
using MTask.Boilerplate.Api.Schema.Persons;
using MTask.Boilerplate.Api.Schema.Planets;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.Application.Planets.Ordering;
using MTask.Boilerplate.Core.Films;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Planets;
using MTask.Extensions.Core.Pagination.Helpers;
using MTask.Extensions.HotChocolate;

namespace MTask.Boilerplate.Api.Schema.Films
{
    public class FilmType : ObjectType<Film>
    {
        protected override void Configure(IObjectTypeDescriptor<Film> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            // Object Name in GraphQL schema 
            descriptor.Name("Film");

            // Implement Node interface 
            // This allows us to support relay specification of graphql allowing base64 IDs   
            descriptor
                .ImplementsNode()
                .IdField(f => f.Id)
                .ResolveNodeWith<FilmByIdsDataLoader>(f => f.LoadAsync(default(int), default));

            // Adds databaseId field to request
            descriptor
                .UseDatabaseId(f => f.Id);

            descriptor
                .Field(f => f.Planets)
                .UseServiceScope() // Create Separate scope because we are not loading data with DataLoader 
                .UseMTaskPaging<PlanetType, PlanetOrder>(async (context, order, paginationRequest) =>
                {
                    Debug.WriteLine("this is informational debug");
                    var currentFilm = context.Parent<Film>();
                    var service = context.Service<IPlanetService>();
                    
                    // Create MTask Pagination Result 
                    PaginationResult<Planet> planets = await service.FilterPlanetsForFilm(currentFilm.Id, order, paginationRequest);

                    // Convert to HotChoco Connection 
                    return planets.ToConnection();
                });
            
            

            descriptor.Field(f => f.Title);
            descriptor.Field(f => f.OpeningCrawl);
            descriptor.Field(f => f.EpisodeId);
            descriptor.Field(f => f.Director);
            descriptor.Field(f => f.Producer);
            descriptor.Field(f => f.ReleaseDate);
            descriptor.Field(f => f.Created);
            descriptor.Field(f => f.LastEdited);
        }
    }
}
