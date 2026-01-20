using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class Mystery2026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MysteryCampaigns",
                columns: new[] { "Id", "End", "Kind", "Price", "Start" },
                values: new object[,]
                {
                    { 7, new DateOnly(2026, 2, 9), 0, 3.0, new DateOnly(2026, 1, 20) },
                    { 8, new DateOnly(2026, 2, 9), 1, 3.0, new DateOnly(2026, 1, 20) },
                }
            );

            migrationBuilder.InsertData(
                table: "MysteryProducts",
                columns: new[] { "Id", "CampaignId", "Chance", "Product2Id", "ProductId" },
                values: new object[,]
                {
                    { 379, 7, 0.15, null, "702" },
                    { 380, 7, 0.03, null, "213" },
                    { 381, 7, 0.08, null, "1110" },
                    { 382, 7, 0.09, null, "2" },
                    { 383, 7, 0.05, null, "1101" },
                    { 384, 7, 0.08, null, "49" },
                    { 385, 7, 0.07, null, "46" },
                    { 386, 7, 0.10, null, "802" },
                    { 387, 7, 0.05, null, "1290" },
                    { 388, 7, 0.02, null, "15" },
                    { 389, 7, 0.025, null, "658" },
                    { 390, 7, 0.025, null, "1053" },
                    { 391, 7, 0.11, null, "463" },
                    { 392, 7, 0.12, null, "433" },
                    { 393, 8, 0.20, null, "664" },
                    { 394, 8, 0.20, null, "666" },
                    { 395, 8, 0.30, null, "801" },
                    { 396, 8, 0.30, null, "508" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 379);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 380);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 381);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 382);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 383);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 384);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 385);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 386);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 387);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 388);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 389);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 390);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 391);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 392);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 393);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 394);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 395);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 396);

            migrationBuilder.DeleteData(table: "MysteryCampaigns", keyColumn: "Id", keyValue: 7);

            migrationBuilder.DeleteData(table: "MysteryCampaigns", keyColumn: "Id", keyValue: 8);

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: "1053");

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: "1290");

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: "433");

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: "508");

            migrationBuilder.DeleteData(table: "Products", keyColumn: "Id", keyValue: "658");
        }
    }
}
