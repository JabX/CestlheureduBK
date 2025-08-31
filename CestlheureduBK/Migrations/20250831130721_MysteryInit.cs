using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class MysteryInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MysteryCampaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<string>(type: "TEXT", nullable: false),
                    Kind = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysteryCampaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MysteryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CampaignId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<string>(type: "TEXT", nullable: true),
                    Chance = table.Column<double>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysteryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MysteryProducts_MysteryCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "MysteryCampaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MysteryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MysteryRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RestaurantId = table.Column<string>(type: "TEXT", nullable: true),
                    RollTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MysteryRolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MysteryRolls_MysteryProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "MysteryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MysteryRolls_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MysteryRolls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MysteryCampaigns",
                columns: new[] { "Id", "Kind", "Month", "Price" },
                values: new object[,]
                {
                    { 1, 0, "2024-09", 2.9 },
                    { 2, 1, "2024-09", 2.9 },
                    { 3, 0, "2025-03", 2.9 },
                    { 4, 1, "2025-03", 2.9 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableInCatalogue", "Energy", "Image", "Name" },
                values: new object[] { "953", false, null, null, "Chicken Spicy" });

            migrationBuilder.InsertData(
                table: "MysteryProducts",
                columns: new[] { "Id", "CampaignId", "Chance", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 0.14, "702" },
                    { 2, 1, 0.12, "2" },
                    { 3, 1, 0.12, "49" },
                    { 4, 1, 0.11, "1101" },
                    { 5, 1, 0.10, "463" },
                    { 6, 1, 0.10, "46" },
                    { 7, 1, 0.07, "953" },
                    { 8, 1, 0.07, "802" },
                    { 9, 1, 0.05, "1055" },
                    { 10, 1, 0.05, "1054" },
                    { 11, 1, 0.04, "17" },
                    { 12, 1, 0.03, "15" },
                    { 13, 2, 0.26, "664" },
                    { 14, 2, 0.26, "544" },
                    { 15, 2, 0.24, "666" },
                    { 16, 2, 0.24, "801" },
                    { 17, 3, 0.16, "2" },
                    { 18, 3, 0.16, "1101" },
                    { 19, 3, 0.14, "702" },
                    { 20, 3, 0.12, "49" },
                    { 21, 3, 0.11, "46" },
                    { 22, 3, 0.11, "802" },
                    { 23, 3, 0.05, "1110" },
                    { 24, 3, 0.04, "1055" },
                    { 25, 3, 0.03, "1054" },
                    { 26, 3, 0.03, "213" },
                    { 27, 3, 0.03, "17" },
                    { 28, 3, 0.02, "15" },
                    { 29, 4, 0.36, "664" },
                    { 30, 4, 0.32, "666" },
                    { 31, 4, 0.32, "801" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MysteryProducts_CampaignId",
                table: "MysteryProducts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_MysteryProducts_ProductId",
                table: "MysteryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MysteryRolls_ProductId",
                table: "MysteryRolls",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MysteryRolls_RestaurantId",
                table: "MysteryRolls",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MysteryRolls_UserId",
                table: "MysteryRolls",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MysteryRolls");

            migrationBuilder.DropTable(
                name: "MysteryProducts");

            migrationBuilder.DropTable(
                name: "MysteryCampaigns");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "953");
        }
    }
}
