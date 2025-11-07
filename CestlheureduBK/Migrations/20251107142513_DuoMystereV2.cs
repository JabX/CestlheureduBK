using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class DuoMystereV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 5,
                column: "Month",
                value: "2025-11-04"
            );

            migrationBuilder.InsertData(
                table: "MysteryCampaigns",
                columns: new[] { "Id", "Kind", "Month", "Price" },
                values: new object[] { 6, 2, "2025-11-07", 5.0 }
            );

            migrationBuilder.InsertData(
                table: "MysteryProducts",
                columns: new[] { "Id", "CampaignId", "Chance", "Product2Id", "ProductId" },
                values: new object[,]
                {
                    { 208, 6, 0.001, "3", "682" },
                    { 209, 6, 0.001, "17", "682" },
                    { 210, 6, 0.001, "15", "682" },
                    { 211, 6, 0.001, "1054", "682" },
                    { 212, 6, 0.001, "1054", "1110" },
                    { 213, 6, 0.001, "3", "1072" },
                    { 214, 6, 0.001, "17", "1072" },
                    { 215, 6, 0.001, "15", "1072" },
                    { 216, 6, 0.001, "16", "1072" },
                    { 217, 6, 0.001, "3", "1073" },
                    { 218, 6, 0.001, "17", "1073" },
                    { 219, 6, 0.001, "15", "1073" },
                    { 220, 6, 0.001, "16", "1073" },
                    { 221, 6, 0.001, "3", "213" },
                    { 222, 6, 0.001, "17", "213" },
                    { 223, 6, 0.001, "15", "213" },
                    { 224, 6, 0.001, "1054", "213" },
                    { 225, 6, 0.001, "1054", "2" },
                    { 226, 6, 0.001, "3", "702" },
                    { 227, 6, 0.001, "17", "702" },
                    { 228, 6, 0.001, "15", "702" },
                    { 229, 6, 0.001, "16", "702" },
                    { 230, 6, 0.001, "46", "49" },
                    { 231, 6, 0.001, "1055", "49" },
                    { 232, 6, 0.001, "46", "46" },
                    { 233, 6, 0.001, "802", "46" },
                    { 234, 6, 0.001, "1055", "46" },
                    { 235, 6, 0.001, "802", "802" },
                    { 236, 6, 0.001, "1055", "802" },
                    { 237, 6, 0.001, "1084", "3" },
                    { 238, 6, 0.001, "77", "3" },
                    { 239, 6, 0.001, "547", "3" },
                    { 240, 6, 0.001, "1084", "17" },
                    { 241, 6, 0.001, "77", "17" },
                    { 242, 6, 0.001, "547", "17" },
                    { 243, 6, 0.001, "1084", "15" },
                    { 244, 6, 0.001, "77", "15" },
                    { 245, 6, 0.001, "547", "15" },
                    { 246, 6, 0.001, "84", "16" },
                    { 247, 6, 0.001, "1084", "16" },
                    { 248, 6, 0.001, "77", "16" },
                    { 249, 6, 0.001, "547", "16" },
                    { 250, 6, 0.002, "46", "1110" },
                    { 251, 6, 0.002, "802", "1110" },
                    { 252, 6, 0.002, "1055", "1110" },
                    { 253, 6, 0.002, "1054", "1072" },
                    { 254, 6, 0.002, "1054", "1073" },
                    { 255, 6, 0.002, "46", "2" },
                    { 256, 6, 0.002, "802", "2" },
                    { 257, 6, 0.002, "1055", "2" },
                    { 258, 6, 0.002, "1054", "702" },
                    { 259, 6, 0.002, "46", "1101" },
                    { 260, 6, 0.002, "802", "1101" },
                    { 261, 6, 0.002, "1055", "1101" },
                    { 262, 6, 0.002, "49", "49" },
                    { 263, 6, 0.002, "802", "49" },
                    { 264, 6, 0.002, "84", "3" },
                    { 265, 6, 0.002, "84", "17" },
                    { 266, 6, 0.002, "84", "15" },
                    { 267, 6, 0.002, "84", "1054" },
                    { 268, 6, 0.002, "1084", "1054" },
                    { 269, 6, 0.002, "77", "1054" },
                    { 270, 6, 0.002, "547", "1054" },
                    { 271, 6, 0.002, "16", "682" },
                    { 272, 6, 0.002, "3", "1110" },
                    { 273, 6, 0.002, "17", "1110" },
                    { 274, 6, 0.002, "15", "1110" },
                    { 275, 6, 0.002, "16", "1110" },
                    { 276, 6, 0.002, "16", "213" },
                    { 277, 6, 0.002, "3", "2" },
                    { 278, 6, 0.002, "17", "2" },
                    { 279, 6, 0.002, "15", "2" },
                    { 280, 6, 0.002, "16", "2" },
                    { 281, 6, 0.002, "3", "1101" },
                    { 282, 6, 0.002, "17", "1101" },
                    { 283, 6, 0.002, "15", "1101" },
                    { 284, 6, 0.002, "1054", "1101" },
                    { 285, 6, 0.002, "17", "49" },
                    { 286, 6, 0.002, "1054", "49" },
                    { 287, 6, 0.002, "1054", "802" },
                    { 288, 6, 0.002, "1055", "1055" },
                    { 289, 6, 0.004, "46", "682" },
                    { 290, 6, 0.004, "802", "682" },
                    { 291, 6, 0.004, "1055", "682" },
                    { 292, 6, 0.004, "2", "1110" },
                    { 293, 6, 0.004, "1101", "1110" },
                    { 294, 6, 0.004, "49", "1110" },
                    { 295, 6, 0.004, "46", "1072" },
                    { 296, 6, 0.004, "1055", "1072" },
                    { 297, 6, 0.004, "46", "1073" },
                    { 298, 6, 0.004, "802", "1073" },
                    { 299, 6, 0.004, "1055", "1073" },
                    { 300, 6, 0.004, "49", "213" },
                    { 301, 6, 0.004, "46", "213" },
                    { 302, 6, 0.004, "802", "213" },
                    { 303, 6, 0.004, "1055", "213" },
                    { 304, 6, 0.004, "2", "2" },
                    { 305, 6, 0.004, "1101", "2" },
                    { 306, 6, 0.004, "49", "2" },
                    { 307, 6, 0.004, "46", "702" },
                    { 308, 6, 0.004, "802", "702" },
                    { 309, 6, 0.004, "1055", "702" },
                    { 310, 6, 0.004, "1101", "1101" },
                    { 311, 6, 0.004, "49", "1101" },
                    { 312, 6, 0.004, "1084", "46" },
                    { 313, 6, 0.004, "77", "46" },
                    { 314, 6, 0.004, "547", "46" },
                    { 315, 6, 0.004, "1084", "802" },
                    { 316, 6, 0.004, "547", "802" },
                    { 317, 6, 0.004, "1084", "1055" },
                    { 318, 6, 0.004, "77", "1055" },
                    { 319, 6, 0.004, "547", "1055" },
                    { 320, 6, 0.004, "1073", "682" },
                    { 321, 6, 0.004, "213", "682" },
                    { 322, 6, 0.004, "1073", "1110" },
                    { 323, 6, 0.004, "1073", "1072" },
                    { 324, 6, 0.004, "213", "1072" },
                    { 325, 6, 0.004, "702", "1073" },
                    { 326, 6, 0.004, "702", "213" },
                    { 327, 6, 0.005, "1110", "682" },
                    { 328, 6, 0.005, "1101", "682" },
                    { 329, 6, 0.005, "1110", "1110" },
                    { 330, 6, 0.005, "213", "1110" },
                    { 331, 6, 0.005, "702", "1110" },
                    { 332, 6, 0.005, "1084", "1110" },
                    { 333, 6, 0.005, "2", "1072" },
                    { 334, 6, 0.005, "1101", "1072" },
                    { 335, 6, 0.005, "2", "1073" },
                    { 336, 6, 0.005, "1101", "1073" },
                    { 337, 6, 0.005, "49", "1073" },
                    { 338, 6, 0.005, "2", "213" },
                    { 339, 6, 0.005, "1101", "213" },
                    { 340, 6, 0.005, "547", "2" },
                    { 341, 6, 0.005, "77", "1101" },
                    { 342, 6, 0.013, "1072", "682" },
                    { 343, 6, 0.013, "702", "682" },
                    { 344, 6, 0.013, "1072", "1110" },
                    { 345, 6, 0.013, "84", "1110" },
                    { 346, 6, 0.013, "77", "1110" },
                    { 347, 6, 0.013, "547", "1110" },
                    { 348, 6, 0.013, "702", "1072" },
                    { 349, 6, 0.013, "84", "1072" },
                    { 350, 6, 0.013, "1084", "1072" },
                    { 351, 6, 0.013, "77", "1072" },
                    { 352, 6, 0.013, "547", "1072" },
                    { 353, 6, 0.013, "84", "2" },
                    { 354, 6, 0.013, "77", "2" },
                    { 355, 6, 0.013, "702", "702" },
                    { 356, 6, 0.013, "547", "702" },
                    { 357, 6, 0.013, "84", "1101" },
                    { 358, 6, 0.018, "802", "1072" },
                    { 359, 6, 0.019, "2", "682" },
                    { 360, 6, 0.019, "49", "682" },
                    { 361, 6, 0.019, "49", "1072" },
                    { 362, 6, 0.019, "702", "2" },
                    { 363, 6, 0.019, "1084", "2" },
                    { 364, 6, 0.019, "1101", "702" },
                    { 365, 6, 0.019, "49", "702" },
                    { 366, 6, 0.019, "1084", "1101" },
                    { 367, 6, 0.019, "547", "1101" },
                    { 368, 6, 0.019, "1084", "49" },
                    { 369, 6, 0.019, "77", "49" },
                    { 370, 6, 0.019, "547", "49" },
                    { 371, 6, 0.019, "84", "46" },
                    { 372, 6, 0.019, "84", "802" },
                    { 373, 6, 0.019, "77", "802" },
                    { 374, 6, 0.019, "84", "1055" },
                    { 375, 6, 0.027, "1084", "702" },
                    { 376, 6, 0.027, "84", "49" },
                    { 377, 6, 0.033, "84", "702" },
                    { 378, 6, 0.033, "77", "702" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 208);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 209);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 210);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 211);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 212);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 213);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 214);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 215);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 216);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 217);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 218);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 219);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 220);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 221);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 222);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 223);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 224);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 225);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 226);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 227);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 228);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 229);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 230);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 231);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 232);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 233);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 234);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 235);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 236);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 237);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 238);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 239);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 240);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 241);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 242);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 243);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 244);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 245);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 246);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 247);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 248);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 249);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 250);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 251);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 252);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 253);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 254);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 255);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 256);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 257);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 258);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 259);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 260);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 261);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 262);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 263);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 264);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 265);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 266);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 267);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 268);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 269);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 270);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 271);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 272);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 273);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 274);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 275);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 276);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 277);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 278);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 279);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 280);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 281);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 282);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 283);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 284);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 285);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 286);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 287);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 288);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 289);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 290);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 291);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 292);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 293);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 294);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 295);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 296);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 297);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 298);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 299);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 300);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 301);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 302);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 303);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 304);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 305);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 306);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 307);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 308);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 309);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 310);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 311);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 312);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 313);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 314);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 315);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 316);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 317);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 318);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 319);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 320);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 321);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 322);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 323);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 324);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 325);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 326);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 327);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 328);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 329);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 330);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 331);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 332);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 333);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 334);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 335);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 336);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 337);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 338);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 339);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 340);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 341);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 342);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 343);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 344);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 345);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 346);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 347);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 348);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 349);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 350);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 351);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 352);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 353);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 354);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 355);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 356);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 357);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 358);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 359);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 360);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 361);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 362);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 363);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 364);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 365);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 366);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 367);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 368);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 369);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 370);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 371);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 372);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 373);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 374);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 375);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 376);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 377);

            migrationBuilder.DeleteData(table: "MysteryProducts", keyColumn: "Id", keyValue: 378);

            migrationBuilder.DeleteData(table: "MysteryCampaigns", keyColumn: "Id", keyValue: 6);

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 5,
                column: "Month",
                value: "2025-11"
            );
        }
    }
}
