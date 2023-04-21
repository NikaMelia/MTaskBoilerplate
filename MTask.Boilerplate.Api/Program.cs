using Microsoft.EntityFrameworkCore;
using MTask.Boilerplate.Api.Schema;
using MTask.Boilerplate.Api.Services;
using MTask.Boilerplate.Application.Films.Configuration;
using MTask.Boilerplate.Application.Persons.Configuration;
using MTask.Boilerplate.Application.Planets.Configuration;
using MTask.Boilerplate.EFCore;
using MTask.Boilerplate.Infrastructure.Utils;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Logger 
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.WithProperty("ServiceName", "MTGames.Operators")
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        b =>
        {
            b.AllowAnyHeader();
            b.AllowAnyOrigin();
            b.AllowAnyMethod();
        });
});

builder.Services.AddDbContext<BoilerplateDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"),
                        b=>b.MigrationsAssembly("MTask.Boilerplate.EFCore")));
builder.Services.AddGrpc();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();

builder.Services.AddBoilerGraphQl();

builder.Services.AddFilmServices();
builder.Services.AddPlanetServices();
builder.Services.AddPersonServices();

var app = builder.Build();
app.MigrateDbContext<BoilerplateDbContext>((_, __) => { });

//Configure grpc
app.MapGrpcService<BoilerplateService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

// To catch and log startup errors 
Log.Information("-------------- Starting up Application ---------------------");
try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "-------------- Application Startup FAILED ---------------------");
}
finally
{
    Log.CloseAndFlush();
}