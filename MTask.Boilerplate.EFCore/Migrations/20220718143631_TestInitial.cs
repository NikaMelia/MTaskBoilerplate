using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTask.Boilerplate.EFCore.Migrations
{
    public partial class TestInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RotationPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gravity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Climate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurfaceWater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarShips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarshipClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostInCredits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HyperdriveRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mglt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarShips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostInCredits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmPlanet",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    PlanetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlanet", x => new { x.FilmsId, x.PlanetsId });
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EyeColor = table.Column<int>(type: "int", nullable: false),
                    BirthYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    HairColor = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    HomeWorldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageLifespan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeWorldId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmStarShip",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    StarShipsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStarShip", x => new { x.FilmsId, x.StarShipsId });
                    table.ForeignKey(
                        name: "FK_FilmStarShip_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmStarShip_StarShips_StarShipsId",
                        column: x => x.StarShipsId,
                        principalTable: "StarShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmVehicle",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmVehicle", x => new { x.FilmsId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmPerson",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPerson", x => new { x.CharactersId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_FilmPerson_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmPerson_People_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonStarShip",
                columns: table => new
                {
                    PilotsId = table.Column<int>(type: "int", nullable: false),
                    StarShipsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStarShip", x => new { x.PilotsId, x.StarShipsId });
                    table.ForeignKey(
                        name: "FK_PersonStarShip_People_PilotsId",
                        column: x => x.PilotsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonStarShip_StarShips_StarShipsId",
                        column: x => x.StarShipsId,
                        principalTable: "StarShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonVehicle",
                columns: table => new
                {
                    PilotsId = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVehicle", x => new { x.PilotsId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_PersonVehicle_People_PilotsId",
                        column: x => x.PilotsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmSpecie",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSpecie", x => new { x.FilmsId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_FilmSpecie_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSpecie_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleSpecies",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SpecieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleSpecies", x => new { x.PersonId, x.SpecieId });
                    table.ForeignKey(
                        name: "FK_PeopleSpecies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeopleSpecies_Species_SpecieId",
                        column: x => x.SpecieId,
                        principalTable: "Species",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmPerson_FilmsId",
                table: "FilmPerson",
                column: "FilmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanet_PlanetsId",
                table: "FilmPlanet",
                column: "PlanetsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSpecie_SpeciesId",
                table: "FilmSpecie",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmStarShip_StarShipsId",
                table: "FilmStarShip",
                column: "StarShipsId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmVehicle_VehiclesId",
                table: "FilmVehicle",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_People_HomeWorldId",
                table: "People",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleSpecies_SpecieId",
                table: "PeopleSpecies",
                column: "SpecieId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonStarShip_StarShipsId",
                table: "PersonStarShip",
                column: "StarShipsId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_VehiclesId",
                table: "PersonVehicle",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_HomeWorldId",
                table: "Species",
                column: "HomeWorldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmPerson");

            migrationBuilder.DropTable(
                name: "FilmPlanet");

            migrationBuilder.DropTable(
                name: "FilmSpecie");

            migrationBuilder.DropTable(
                name: "FilmStarShip");

            migrationBuilder.DropTable(
                name: "FilmVehicle");

            migrationBuilder.DropTable(
                name: "PeopleSpecies");

            migrationBuilder.DropTable(
                name: "PersonStarShip");

            migrationBuilder.DropTable(
                name: "PersonVehicle");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "StarShips");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
