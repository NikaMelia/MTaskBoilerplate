using HotChocolate.Types;
using MTask.Boilerplate.Application.Films;
using MTask.Boilerplate.Application.Films.Ordering;
using MTask.Boilerplate.Core.Films;
using MTask.Extensions.Core.Pagination.Helpers;
using MTask.Extensions.HotChocolate;

namespace MTask.Boilerplate.Api.Schema.Films
{
    public class FilmQueryType : ObjectTypeExtension<FilmQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<FilmQueries> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor
                .Field("films")
                .UseMTaskPaging<FilmType, FilmOrder>(async (context, order, paginationRequest) =>
                {
                    var service = context.Service<IFilmService>();

                    PaginationResult<Film> films = await service.GetAllFilms(order, paginationRequest);

                    return films.ToConnection();
                });
        }
    }
}
