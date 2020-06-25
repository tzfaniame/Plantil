using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plantil.API.Migrations
{
    public partial class AddExperimentseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("456eab08-de55-47ff-936b-fd7c32fd8299"));

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("75f07f96-a81d-42c3-83ca-4378958e1374"));

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("8875b575-de53-4382-a18b-e27b68d48cfb"));

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Family", "Genus", "Multiplication", "Name", "PlantingDate" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), null, "Citrus", 0, "Limequat", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Family", "Genus", "Multiplication", "Name", "PlantingDate" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), null, "Citrus", 0, "Kumquat", new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "Family", "Genus", "Multiplication", "Name", "PlantingDate" },
                values: new object[] { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), null, "Rosa", 3, "Rose", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Experiments",
                columns: new[] { "Id", "Description", "ExperimentDate", "Location", "PlantId" },
                values: new object[,]
                {
                    { new Guid("d683b791-6997-4b1f-991b-29f64cd9b359"), "שתילת עציץ במרפסת", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("18d32c5b-f82f-47d3-b55a-6628c4d713d7"), "קטימת עלים תחתונים", new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("6b867efa-fd5d-4cfa-ad6d-589386e5d7f4"), "העברת עץ מאדמה לדלי", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("3ca7795f-3c7d-4f3c-a61e-b14631153149"), "השקייה מלאה", new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("f9c571fd-2c6d-44f6-b21e-74923dc88764"), "קטימת קצות ענפים", new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") },
                    { new Guid("7c4d1192-90f1-4e52-829d-f31aa4377643"), "הדליה אופקית", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("2902b665-1190-4c70-9915-b9c2d7680450") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("18d32c5b-f82f-47d3-b55a-6628c4d713d7"));

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("3ca7795f-3c7d-4f3c-a61e-b14631153149"));

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("6b867efa-fd5d-4cfa-ad6d-589386e5d7f4"));

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("7c4d1192-90f1-4e52-829d-f31aa4377643"));

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("d683b791-6997-4b1f-991b-29f64cd9b359"));

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("f9c571fd-2c6d-44f6-b21e-74923dc88764"));

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"));

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));

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
        }
    }
}
