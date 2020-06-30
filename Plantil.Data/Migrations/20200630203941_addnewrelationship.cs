using Microsoft.EntityFrameworkCore.Migrations;

namespace Plantil.Data.Migrations
{
    public partial class addnewrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiments_Plants_PlantId",
                table: "Experiments");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Experiments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "GrowthRecommends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recommend = table.Column<string>(nullable: true),
                    PlantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthRecommends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrowthRecommends_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(nullable: false),
                    PlantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planters_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantExperiment",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false),
                    ExperimentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantExperiment", x => new { x.PlantId, x.ExperimentId });
                    table.ForeignKey(
                        name: "FK_PlantExperiment_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantExperiment_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrowthRecommends_PlantId",
                table: "GrowthRecommends",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Planters_PlantId",
                table: "Planters",
                column: "PlantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantExperiment_ExperimentId",
                table: "PlantExperiment",
                column: "ExperimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiments_Plants_PlantId",
                table: "Experiments",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiments_Plants_PlantId",
                table: "Experiments");

            migrationBuilder.DropTable(
                name: "GrowthRecommends");

            migrationBuilder.DropTable(
                name: "Planters");

            migrationBuilder.DropTable(
                name: "PlantExperiment");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "Experiments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiments_Plants_PlantId",
                table: "Experiments",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
