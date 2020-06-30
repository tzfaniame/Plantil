using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plantil.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxonomys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genus = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxonomys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlantingDate = table.Column<DateTime>(nullable: false),
                    Multiplication = table.Column<int>(nullable: false),
                    TaxonomyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Taxonomys_TaxonomyId",
                        column: x => x.TaxonomyId,
                        principalTable: "Taxonomys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(nullable: false),
                    ExperimentDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Experiments_PlantId",
                table: "Experiments",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_TaxonomyId",
                table: "Plants",
                column: "TaxonomyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiments");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Taxonomys");
        }
    }
}
