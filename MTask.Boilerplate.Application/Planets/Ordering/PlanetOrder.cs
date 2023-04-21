using MTask.Extensions.Core.Pagination;

namespace MTask.Boilerplate.Application.Planets.Ordering;

/// <summary>
/// Ordering options for Planets.
/// </summary>
public class PlanetOrder
{
    public OrderDirection Direction { get; set; }
    public PlanetOrderField Field { get; set; }
}

/// <summary>
/// Properties by which Field connections can be ordered.
/// </summary>
public enum PlanetOrderField
{
    Id,
    Name,
}