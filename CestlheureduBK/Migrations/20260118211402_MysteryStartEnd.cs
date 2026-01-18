using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class MysteryStartEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "Month", table: "MysteryCampaigns", newName: "Start");

            migrationBuilder.AddColumn<DateOnly>(name: "End", table: "MysteryCampaigns", type: "TEXT", nullable: true);

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateOnly(2024, 9, 30), new DateOnly(2024, 9, 3) }
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateOnly(2024, 9, 30), new DateOnly(2024, 9, 3) }
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateOnly(2025, 3, 31), new DateOnly(2025, 3, 4) }
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateOnly(2025, 3, 31), new DateOnly(2025, 3, 4) }
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateOnly(2025, 11, 6), new DateOnly(2025, 11, 4) }
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "End", "Start" },
                values: new object[] { new DateOnly(2025, 11, 24), new DateOnly(2025, 11, 7) }
            );

            migrationBuilder.AlterColumn<DateOnly>(
                name: "End",
                table: "MysteryCampaigns",
                type: "TEXT",
                nullable: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "End", table: "MysteryCampaigns");

            migrationBuilder.RenameColumn(name: "Start", table: "MysteryCampaigns", newName: "Month");

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Month",
                value: "2024-09"
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Month",
                value: "2024-09"
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Month",
                value: "2025-03"
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 4,
                column: "Month",
                value: "2025-03"
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 5,
                column: "Month",
                value: "2025-11-04"
            );

            migrationBuilder.UpdateData(
                table: "MysteryCampaigns",
                keyColumn: "Id",
                keyValue: 6,
                column: "Month",
                value: "2025-11-07"
            );
        }
    }
}
