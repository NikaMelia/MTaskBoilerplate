﻿// <auto-generated />
using System;
using MTask.Boilerplate.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MTask.Boilerplate.EFCore.Migrations
{
    [DbContext(typeof(BoilerplateDbContext))]
    partial class BoilerplateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FilmPerson", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("FilmPerson");
                });

            modelBuilder.Entity("FilmPlanet", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("PlanetsId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "PlanetsId");

                    b.HasIndex("PlanetsId");

                    b.ToTable("FilmPlanet");
                });

            modelBuilder.Entity("FilmSpecie", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("FilmSpecie");
                });

            modelBuilder.Entity("FilmStarShip", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("StarShipsId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "StarShipsId");

                    b.HasIndex("StarShipsId");

                    b.ToTable("FilmStarShip");
                });

            modelBuilder.Entity("FilmVehicle", b =>
                {
                    b.Property<int>("FilmsId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("FilmsId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("FilmVehicle");
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Films.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastEdited")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("OpeningCrawl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films", (string)null);
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.People.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BirthYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("EyeColor")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("HairColor")
                        .HasColumnType("int");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeWorldId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastEdited")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Mass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeWorldId");

                    b.ToTable("People", (string)null);
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.PeopleSpecies", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("SpecieId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "SpecieId");

                    b.HasIndex("SpecieId");

                    b.ToTable("PeopleSpecies");
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Planets.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Diameter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Edited")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Gravity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrbitalPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RotationPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurfaceWater")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Terrain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planets", (string)null);
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Species.Specie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AverageHeight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AverageLifespan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeWorldId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkinColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeWorldId");

                    b.ToTable("Species", (string)null);
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Starships.StarShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HyperdriveRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEdited")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxAtmospheringSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mglt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StarshipClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StarShips", (string)null);
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEdited")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxAtmospheringSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("PersonStarShip", b =>
                {
                    b.Property<int>("PilotsId")
                        .HasColumnType("int");

                    b.Property<int>("StarShipsId")
                        .HasColumnType("int");

                    b.HasKey("PilotsId", "StarShipsId");

                    b.HasIndex("StarShipsId");

                    b.ToTable("PersonStarShip");
                });

            modelBuilder.Entity("PersonVehicle", b =>
                {
                    b.Property<int>("PilotsId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("PilotsId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("PersonVehicle");
                });

            modelBuilder.Entity("FilmPerson", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.People.Person", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Films.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmPlanet", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.Films.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Planets.Planet", null)
                        .WithMany()
                        .HasForeignKey("PlanetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmSpecie", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.Films.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Species.Specie", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmStarShip", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.Films.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Starships.StarShip", null)
                        .WithMany()
                        .HasForeignKey("StarShipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmVehicle", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.Films.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.People.Person", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.Planets.Planet", "HomeWorld")
                        .WithMany("Residents")
                        .HasForeignKey("HomeWorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeWorld");
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.PeopleSpecies", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.People.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("MTask.Boilerplate.Core.Species.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Species.Specie", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.Planets.Planet", "HomeWorld")
                        .WithMany()
                        .HasForeignKey("HomeWorldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeWorld");
                });

            modelBuilder.Entity("PersonStarShip", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.People.Person", null)
                        .WithMany()
                        .HasForeignKey("PilotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Starships.StarShip", null)
                        .WithMany()
                        .HasForeignKey("StarShipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonVehicle", b =>
                {
                    b.HasOne("MTask.Boilerplate.Core.People.Person", null)
                        .WithMany()
                        .HasForeignKey("PilotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTask.Boilerplate.Core.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MTask.Boilerplate.Core.Planets.Planet", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
