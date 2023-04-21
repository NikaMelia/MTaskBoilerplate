using MTask.Extensions.Core.Pagination;

namespace MTask.Boilerplate.Application.Films.Ordering;

/// <summary>
/// Ordering options for films.
/// </summary>
public class FilmOrder
{
    public OrderDirection Direction { get; set; }
    public FilmOrderField Field { get; set; }
}


/// <summary>
/// Properties by which Field connections can be ordered.
/// </summary>
public enum FilmOrderField
{
    Id,
    Title
}