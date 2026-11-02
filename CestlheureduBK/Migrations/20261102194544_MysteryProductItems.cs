using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CestlheureduBK.Migrations;

public partial class MysteryProductItems : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MysteryProductItems",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                MysteryProductId = table.Column<int>(type: "INTEGER", nullable: false),
                ProductId = table.Column<string>(type: "TEXT", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MysteryProductItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_MysteryProductItems_MysteryProducts_MysteryProductId",
                    column: x => x.MysteryProductId,
                    principalTable: "MysteryProducts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_MysteryProductItems_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.Sql("""
            INSERT INTO "MysteryProductItems" ("Id", "MysteryProductId", "ProductId")
            SELECT ROW_NUMBER() OVER (ORDER BY "MysteryProductId", "Slot"), "MysteryProductId", "ProductId"
            FROM (
                SELECT "Id" AS "MysteryProductId", 0 AS "Slot", "ProductId"
                FROM "MysteryProducts" WHERE "ProductId" IS NOT NULL
                UNION ALL
                SELECT "Id", 1, "Product2Id"
                FROM "MysteryProducts" WHERE "Product2Id" IS NOT NULL
            );
            """);

        migrationBuilder.DropForeignKey(name: "FK_MysteryProducts_Products_Product2Id", table: "MysteryProducts");
        migrationBuilder.DropForeignKey(name: "FK_MysteryProducts_Products_ProductId", table: "MysteryProducts");
        migrationBuilder.DropIndex(name: "IX_MysteryProducts_Product2Id", table: "MysteryProducts");
        migrationBuilder.DropIndex(name: "IX_MysteryProducts_ProductId", table: "MysteryProducts");
        migrationBuilder.DropColumn(name: "Product2Id", table: "MysteryProducts");
        migrationBuilder.DropColumn(name: "ProductId", table: "MysteryProducts");

        migrationBuilder.CreateIndex(
            name: "IX_MysteryProductItems_MysteryProductId",
            table: "MysteryProductItems",
            column: "MysteryProductId");

        migrationBuilder.CreateIndex(
            name: "IX_MysteryProductItems_ProductId",
            table: "MysteryProductItems",
            column: "ProductId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }
}