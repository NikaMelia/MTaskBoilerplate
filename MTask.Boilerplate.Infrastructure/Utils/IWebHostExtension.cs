using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.EFCore;

namespace MTask.Boilerplate.Infrastructure.Utils;

public static class IWebHostExtensions
{
    public static WebApplication MigrateDbContext<TContext>(this WebApplication webHost,
        Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using var scope = webHost.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetService<TContext>();
        if (context == null)
            return webHost;
        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}",
                typeof(TContext).Name);
            InvokeSeeder<TContext>(seeder, context, services);
            logger.LogInformation("Migrated database associated with context {DbContextName}",
                typeof(TContext).Name);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}",
                typeof(TContext).Name);
            throw; // Rethrow under k8s because we rely on k8s to re-run the pod
        }

        return webHost;
    }

    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context,
        IServiceProvider services)
        where TContext : DbContext
    {
        context.Database.Migrate();
        seeder(context, services);
    }


}