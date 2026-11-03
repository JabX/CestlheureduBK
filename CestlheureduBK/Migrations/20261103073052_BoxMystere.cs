using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class BoxMystere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MysteryCampaigns",
                columns: new[] { "Id", "End", "Kind", "Price", "Start" },
                values: new object[] { 9, new DateOnly(2026, 11, 23), 3, 10.0, new DateOnly(2026, 11, 3) });

            migrationBuilder.InsertData(
                table: "MysteryProducts",
                columns: new[] { "Id", "CampaignId", "Chance" },
                values: new object[,]
                {
                    { 397, 9, 0.042999999999999997 },
                    { 398, 9, 0.057000000000000002 },
                    { 399, 9, 0.059999999999999998 },
                    { 400, 9, 0.01 },
                    { 401, 9, 0.029999999999999999 },
                    { 402, 9, 0.059999999999999998 },
                    { 403, 9, 0.058999999999999997 },
                    { 404, 9, 0.014999999999999999 },
                    { 405, 9, 0.059999999999999998 },
                    { 406, 9, 0.047 },
                    { 407, 9, 0.059999999999999998 },
                    { 408, 9, 0.042999999999999997 },
                    { 409, 9, 0.034000000000000002 },
                    { 410, 9, 0.056000000000000001 },
                    { 411, 9, 0.014 },
                    { 412, 9, 0.040000000000000001 },
                    { 413, 9, 0.040000000000000001 },
                    { 414, 9, 0.02 },
                    { 415, 9, 0.050000000000000003 },
                    { 416, 9, 0.036999999999999998 },
                    { 417, 9, 0.035000000000000003 },
                    { 418, 9, 0.0050000000000000001 },
                    { 419, 9, 0.0050000000000000001 },
                    { 420, 9, 0.02 },
                    { 421, 9, 0.02 },
                    { 422, 9, 0.059999999999999998 },
                    { 423, 9, 0.01 },
                    { 424, 9, 0.01 }
                });

            migrationBuilder.InsertData(
                table: "MysteryProductItems",
                columns: new[] { "Id", "MysteryProductId", "ProductId" },
                values: new object[,]
                {
                    { 744, 397, "49" },
                    { 745, 397, "1400" },
                    { 746, 397, "1276" },
                    { 747, 397, "53" },
                    { 748, 398, "49" },
                    { 749, 398, "1400" },
                    { 750, 398, "83" },
                    { 751, 398, "53" },
                    { 752, 399, "49" },
                    { 753, 399, "1398" },
                    { 754, 399, "73" },
                    { 755, 399, "53" },
                    { 756, 400, "49" },
                    { 757, 400, "1402" },
                    { 758, 400, "76" },
                    { 759, 400, "53" },
                    { 760, 401, "49" },
                    { 761, 401, "1328" },
                    { 762, 401, "83" },
                    { 763, 401, "53" },
                    { 764, 402, "2" },
                    { 765, 402, "1400" },
                    { 766, 402, "83" },
                    { 767, 402, "53" },
                    { 768, 403, "2" },
                    { 769, 403, "1398" },
                    { 770, 403, "73" },
                    { 771, 403, "53" },
                    { 772, 404, "2" },
                    { 773, 404, "1398" },
                    { 774, 404, "1276" },
                    { 775, 404, "53" },
                    { 776, 405, "2" },
                    { 777, 405, "1401" },
                    { 778, 405, "83" },
                    { 779, 405, "53" },
                    { 780, 406, "2" },
                    { 781, 406, "1401" },
                    { 782, 406, "76" },
                    { 783, 406, "53" },
                    { 784, 407, "1511" },
                    { 785, 407, "1400" },
                    { 786, 407, "83" },
                    { 787, 407, "53" },
                    { 788, 408, "1511" },
                    { 789, 408, "1400" },
                    { 790, 408, "73" },
                    { 791, 408, "53" },
                    { 792, 409, "1511" },
                    { 793, 409, "1398" },
                    { 794, 409, "76" },
                    { 795, 409, "53" },
                    { 796, 410, "1511" },
                    { 797, 410, "1402" },
                    { 798, 410, "76" },
                    { 799, 410, "53" },
                    { 800, 411, "1511" },
                    { 801, 411, "1101" },
                    { 802, 411, "83" },
                    { 803, 411, "53" },
                    { 804, 412, "1511" },
                    { 805, 412, "1101" },
                    { 806, 412, "83" },
                    { 807, 412, "53" },
                    { 808, 413, "1396" },
                    { 809, 413, "1398" },
                    { 810, 413, "73" },
                    { 811, 413, "53" },
                    { 812, 414, "46" },
                    { 813, 414, "1398" },
                    { 814, 414, "73" },
                    { 815, 414, "53" },
                    { 816, 415, "46" },
                    { 817, 415, "1401" },
                    { 818, 415, "76" },
                    { 819, 415, "53" },
                    { 820, 416, "802" },
                    { 821, 416, "1400" },
                    { 822, 416, "83" },
                    { 823, 416, "53" },
                    { 824, 417, "802" },
                    { 825, 417, "1328" },
                    { 826, 417, "73" },
                    { 827, 417, "53" },
                    { 828, 418, "3" },
                    { 829, 418, "1400" },
                    { 830, 418, "76" },
                    { 831, 418, "53" },
                    { 832, 419, "15" },
                    { 833, 419, "1400" },
                    { 834, 419, "76" },
                    { 835, 419, "53" },
                    { 836, 420, "16" },
                    { 837, 420, "1401" },
                    { 838, 420, "83" },
                    { 839, 420, "53" },
                    { 840, 421, "17" },
                    { 841, 421, "1398" },
                    { 842, 421, "83" },
                    { 843, 421, "53" },
                    { 844, 422, "1512" },
                    { 845, 422, "1398" },
                    { 846, 422, "76" },
                    { 847, 422, "53" },
                    { 848, 423, "658" },
                    { 849, 423, "1400" },
                    { 850, 423, "83" },
                    { 851, 423, "53" },
                    { 852, 424, "1602" },
                    { 853, 424, "1398" },
                    { 854, 424, "76" },
                    { 855, 424, "53" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 835);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 836);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 837);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 838);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 839);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 841);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 842);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 843);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 844);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 845);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 846);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 847);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 848);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 849);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 851);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 852);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 853);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "MysteryProductItems",
                keyColumn: "Id",
                keyValue: 855);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "MysteryProducts",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
