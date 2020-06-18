using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plantil.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Genus = table.Column<string>(nullable: false),
                    Family = table.Column<string>(nullable: true),
                    PlantingDate = table.Column<DateTime>(nullable: false),
                    Multiplication = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlantId = table.Column<Guid>(nullable: false),
                    ExperimentDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiments_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Family", "Genus", "Multiplication", "Name", "PlantingDate" },
                values: new object[] { new Guid("75f07f96-a81d-42c3-83ca-4378958e1374"), null, "Citrus", 0, "Limequat", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Family", "Genus", "Multiplication", "Name", "PlantingDate" },
                values: new object[] { new Guid("8875b575-de53-4382-a18b-e27b68d48cfb"), null, "Citrus", 0, "Kumquat", new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Family", "Genus", "Multiplication", "Name", "PlantingDate" },
                values: new object[] { new Guid("456eab08-de55-47ff-936b-fd7c32fd8299"), null, "Rosa", 3, "Rose", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_PlantId",
                table: "Experiments",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiments");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
