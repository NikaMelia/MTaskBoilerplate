using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MTask.Boilerplate.EFCore.Seeder;

public static class DbContextSeeder
{
    public static void Seeder(DbContext dbContext, IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var seederDataProvider = services.GetRequiredService<ISeedDataProvider>();
        dbContext.AddRange(seederDataProvider.GetFilmsData());
        dbContext.AddRange(seederDataProvider.GetPeopleData());
        dbContext.AddRange(seederDataProvider.GetPlanetsData());
        dbContext.AddRange(seederDataProvider.GetSpeciesData());
        dbContext.AddRange(seederDataProvider.GetVehiclesData());
        dbContext.AddRange(seederDataProvider.GetStarShipsData());
        dbContext.SaveChangesAsync();
    }
}