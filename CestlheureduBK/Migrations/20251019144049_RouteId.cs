using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class RouteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteId",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: ""
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "RouteId", table: "Products");
        }
    }
}
