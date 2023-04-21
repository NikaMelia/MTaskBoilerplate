using HotChocolate.Types;
using MTask.Boilerplate.Application.Planets;
using MTask.Boilerplate.Application.Planets.Ordering;
using MTask.Boilerplate.Core.Planets;
using MTask.Extensions.Core.Pagination.Helpers;
using MTask.Extensions.HotChocolate;

namespace MTask.Boilerplate.Api.Schema.Planets
{
    public class PlanetQueryType : ObjectTypeExtension<PlanetQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<PlanetQueries> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor
                .Field("planets")
                .UseMTaskPaging<PlanetType, PlanetOrder>(async (context, order, paginationRequest) =>
                {
                    var service = context.Service<IPlanetService>();

                    PaginationResult<Planet> planets = await service.GetAllPlanets(order, paginationRequest);

                    return planets.ToConnection();
                });
        }
    }
}
