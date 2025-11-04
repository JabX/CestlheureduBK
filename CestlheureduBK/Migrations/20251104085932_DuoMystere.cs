using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class DuoMystere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product2Id",
                table: "MysteryProducts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MysteryCampaigns",
                columns: new[] { "Id", "Kind", "Month", "Price" },
                values: new object[] { 5, 2, "2025-11", 5.0 });

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 11,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 12,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 13,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 14,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 15,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 16,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 17,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 18,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 19,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 20,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 21,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 22,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 23,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 25,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 26,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 27,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 28,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 29,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 30,
                column: "Product2Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 31,
                column: "Product2Id",
                value: null);

            migrationBuilder.InsertData(
                table: "MysteryProducts",
                columns: new[] { "Id", "CampaignId", "Chance", "Product2Id", "ProductId" },
                values: new object[,]
                {
                    { 32, 5, 0.033000000000000002, "1073", "1072" },
                    { 33, 5, 0.033000000000000002, "84", "1072" },
                    { 34, 5, 0.033000000000000002, "1084", "1072" },
                    { 35, 5, 0.033000000000000002, "77", "1072" },
                    { 36, 5, 0.033000000000000002, "547", "1072" },
                    { 37, 5, 0.033000000000000002, "1073", "1073" },
                    { 38, 5, 0.033000000000000002, "84", "702" },
                    { 39, 5, 0.033000000000000002, "77", "702" },
                    { 40, 5, 0.012999999999999999, "682", "682" },
                    { 41, 5, 0.012999999999999999, "1072", "682" },
                    { 42, 5, 0.012999999999999999, "1073", "682" },
                    { 43, 5, 0.012999999999999999, "213", "682" },
                    { 44, 5, 0.012999999999999999, "702", "682" },
                    { 45, 5, 0.012999999999999999, "1072", "1110" },
                    { 46, 5, 0.012999999999999999, "1073", "1110" },
                    { 47, 5, 0.012999999999999999, "84", "1110" },
                    { 48, 5, 0.012999999999999999, "77", "1110" },
                    { 49, 5, 0.012999999999999999, "547", "1110" },
                    { 50, 5, 0.012999999999999999, "213", "1072" },
                    { 51, 5, 0.012999999999999999, "702", "1072" },
                    { 52, 5, 0.012999999999999999, "213", "1073" },
                    { 53, 5, 0.012999999999999999, "702", "1073" },
                    { 54, 5, 0.012999999999999999, "213", "213" },
                    { 55, 5, 0.012999999999999999, "702", "213" },
                    { 56, 5, 0.012999999999999999, "84", "2" },
                    { 57, 5, 0.012999999999999999, "77", "2" },
                    { 58, 5, 0.012999999999999999, "702", "702" },
                    { 59, 5, 0.012999999999999999, "1084", "702" },
                    { 60, 5, 0.012999999999999999, "547", "702" },
                    { 61, 5, 0.012999999999999999, "84", "1101" },
                    { 62, 5, 0.012999999999999999, "84", "49" },
                    { 63, 5, 0.0050000000000000001, "1110", "682" },
                    { 64, 5, 0.0050000000000000001, "2", "682" },
                    { 65, 5, 0.0050000000000000001, "1101", "682" },
                    { 66, 5, 0.0050000000000000001, "49", "682" },
                    { 67, 5, 0.0050000000000000001, "1110", "1110" },
                    { 68, 5, 0.0050000000000000001, "213", "1110" },
                    { 69, 5, 0.0050000000000000001, "702", "1110" },
                    { 70, 5, 0.0050000000000000001, "1084", "1110" },
                    { 71, 5, 0.0050000000000000001, "2", "1072" },
                    { 72, 5, 0.0050000000000000001, "1101", "1072" },
                    { 73, 5, 0.0050000000000000001, "49", "1072" },
                    { 74, 5, 0.0050000000000000001, "2", "1073" },
                    { 75, 5, 0.0050000000000000001, "1101", "1073" },
                    { 76, 5, 0.0050000000000000001, "49", "1073" },
                    { 77, 5, 0.0050000000000000001, "2", "213" },
                    { 78, 5, 0.0050000000000000001, "1101", "213" },
                    { 79, 5, 0.0050000000000000001, "702", "2" },
                    { 80, 5, 0.0050000000000000001, "1084", "2" },
                    { 81, 5, 0.0050000000000000001, "547", "2" },
                    { 82, 5, 0.0050000000000000001, "1101", "702" },
                    { 83, 5, 0.0050000000000000001, "49", "702" },
                    { 84, 5, 0.0050000000000000001, "1084", "1101" },
                    { 85, 5, 0.0050000000000000001, "77", "1101" },
                    { 86, 5, 0.0050000000000000001, "547", "1101" },
                    { 87, 5, 0.0050000000000000001, "1084", "49" },
                    { 88, 5, 0.0050000000000000001, "77", "49" },
                    { 89, 5, 0.0050000000000000001, "547", "49" },
                    { 90, 5, 0.0050000000000000001, "84", "46" },
                    { 91, 5, 0.0050000000000000001, "84", "802" },
                    { 92, 5, 0.0050000000000000001, "77", "802" },
                    { 93, 5, 0.0050000000000000001, "84", "1055" },
                    { 94, 5, 0.0040000000000000001, "46", "682" },
                    { 95, 5, 0.0040000000000000001, "802", "682" },
                    { 96, 5, 0.0040000000000000001, "1055", "682" },
                    { 97, 5, 0.0040000000000000001, "2", "1110" },
                    { 98, 5, 0.0040000000000000001, "1101", "1110" },
                    { 99, 5, 0.0040000000000000001, "49", "1110" },
                    { 100, 5, 0.0040000000000000001, "46", "1072" },
                    { 101, 5, 0.0040000000000000001, "802", "1072" },
                    { 102, 5, 0.0040000000000000001, "1055", "1072" },
                    { 103, 5, 0.0040000000000000001, "46", "1073" },
                    { 104, 5, 0.0040000000000000001, "802", "1073" },
                    { 105, 5, 0.0040000000000000001, "1055", "1073" },
                    { 106, 5, 0.0040000000000000001, "49", "213" },
                    { 107, 5, 0.0040000000000000001, "46", "213" },
                    { 108, 5, 0.0040000000000000001, "802", "213" },
                    { 109, 5, 0.0040000000000000001, "1055", "213" },
                    { 110, 5, 0.0040000000000000001, "2", "2" },
                    { 111, 5, 0.0040000000000000001, "1101", "2" },
                    { 112, 5, 0.0040000000000000001, "49", "2" },
                    { 113, 5, 0.0040000000000000001, "46", "702" },
                    { 114, 5, 0.0040000000000000001, "802", "702" },
                    { 115, 5, 0.0040000000000000001, "1055", "702" },
                    { 116, 5, 0.0040000000000000001, "1101", "1101" },
                    { 117, 5, 0.0040000000000000001, "49", "1101" },
                    { 118, 5, 0.0040000000000000001, "1084", "46" },
                    { 119, 5, 0.0040000000000000001, "77", "46" },
                    { 120, 5, 0.0040000000000000001, "547", "46" },
                    { 121, 5, 0.0040000000000000001, "1084", "802" },
                    { 122, 5, 0.0040000000000000001, "547", "802" },
                    { 123, 5, 0.0040000000000000001, "1084", "1055" },
                    { 124, 5, 0.0040000000000000001, "77", "1055" },
                    { 125, 5, 0.0040000000000000001, "547", "1055" },
                    { 126, 5, 0.002, "16", "682" },
                    { 127, 5, 0.002, "3", "1110" },
                    { 128, 5, 0.002, "17", "1110" },
                    { 129, 5, 0.002, "15", "1110" },
                    { 130, 5, 0.002, "16", "1110" },
                    { 131, 5, 0.002, "16", "213" },
                    { 132, 5, 0.002, "3", "2" },
                    { 133, 5, 0.002, "17", "2" },
                    { 134, 5, 0.002, "15", "2" },
                    { 135, 5, 0.002, "16", "2" },
                    { 136, 5, 0.002, "3", "1101" },
                    { 137, 5, 0.002, "17", "1101" },
                    { 138, 5, 0.002, "15", "1101" },
                    { 139, 5, 0.002, "1054", "1101" },
                    { 140, 5, 0.002, "17", "49" },
                    { 141, 5, 0.002, "1054", "49" },
                    { 142, 5, 0.002, "1054", "802" },
                    { 143, 5, 0.002, "1055", "1055" },
                    { 144, 5, 0.002, "46", "1110" },
                    { 145, 5, 0.002, "802", "1110" },
                    { 146, 5, 0.002, "1055", "1110" },
                    { 147, 5, 0.002, "1054", "1072" },
                    { 148, 5, 0.002, "1054", "1073" },
                    { 149, 5, 0.002, "46", "2" },
                    { 150, 5, 0.002, "802", "2" },
                    { 151, 5, 0.002, "1055", "2" },
                    { 152, 5, 0.002, "1054", "702" },
                    { 153, 5, 0.002, "46", "1101" },
                    { 154, 5, 0.002, "802", "1101" },
                    { 155, 5, 0.002, "1055", "1101" },
                    { 156, 5, 0.002, "49", "49" },
                    { 157, 5, 0.002, "802", "49" },
                    { 158, 5, 0.002, "84", "3" },
                    { 159, 5, 0.002, "84", "17" },
                    { 160, 5, 0.002, "84", "15" },
                    { 161, 5, 0.002, "84", "1054" },
                    { 162, 5, 0.002, "1084", "1054" },
                    { 163, 5, 0.002, "77", "1054" },
                    { 164, 5, 0.002, "547", "1054" },
                    { 165, 5, 0.001, "3", "682" },
                    { 166, 5, 0.001, "17", "682" },
                    { 167, 5, 0.001, "15", "682" },
                    { 168, 5, 0.001, "1054", "682" },
                    { 169, 5, 0.001, "1054", "1110" },
                    { 170, 5, 0.001, "3", "1072" },
                    { 171, 5, 0.001, "17", "1072" },
                    { 172, 5, 0.001, "15", "1072" },
                    { 173, 5, 0.001, "16", "1072" },
                    { 174, 5, 0.001, "3", "1073" },
                    { 175, 5, 0.001, "17", "1073" },
                    { 176, 5, 0.001, "15", "1073" },
                    { 177, 5, 0.001, "16", "1073" },
                    { 178, 5, 0.001, "3", "213" },
                    { 179, 5, 0.001, "17", "213" },
                    { 180, 5, 0.001, "15", "213" },
                    { 181, 5, 0.001, "1054", "213" },
                    { 182, 5, 0.001, "1054", "2" },
                    { 183, 5, 0.001, "3", "702" },
                    { 184, 5, 0.001, "17", "702" },
                    { 185, 5, 0.001, "15", "702" },
                    { 186, 5, 0.001, "16", "702" },
                    { 187, 5, 0.001, "46", "49" },
                    { 188, 5, 0.001, "1055", "49" },
                    { 189, 5, 0.001, "46", "46" },
                    { 190, 5, 0.001, "802", "46" },
                    { 191, 5, 0.001, "1055", "46" },
                    { 192, 5, 0.001, "802", "802" },
                    { 193, 5, 0.001, "1055", "802" },
                    { 194, 5, 0.001, "1084", "3" },
                    { 195, 5, 0.001, "77", "3" },
                    { 196, 5, 0.001, "547", "3" },
                    { 197, 5, 0.001, "1084", "17" },
                    { 198, 5, 0.001, "77", "17" },
                    { 199, 5, 0.001, "547", "17" },
                    { 200, 5, 0.001, "1084", "15" },
                    { 201, 5, 0.001, "77", "15" },
                    { 202, 5, 0.001, "547", "15" },
                    { 203, 5, 0.001, "84", "16" },
                    { 204, 5, 0.001, "1084", "16" },
                    { 205, 5, 0.001, "77", "16" },
                    { 206, 5, 0.001, "547", "16" },
                    { 207, 5, 0.033000000000000002, "1072", "1072" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MysteryProducts_Product2Id",
                table: "MysteryProducts",
                column: "Product2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MysteryProducts_Products_Product2Id",
                table: "MysteryProducts",
                column: "Product2Id",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MysteryProducts_Products_Product2Id",
                table: "MysteryProducts");

            migrationBuilder.DropIndex(
                name: "IX_MysteryProducts_Product2Id",
                table: "MysteryProducts");

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Product2Id",
                table: "MysteryProducts");
        }
    }
}
