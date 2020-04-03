using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class LocationLongtoDec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                schema: "Portal",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                schema: "Portal",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Long",
                schema: "Portal",
                table: "Locations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Lat",
                schema: "Portal",
                table: "Locations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
