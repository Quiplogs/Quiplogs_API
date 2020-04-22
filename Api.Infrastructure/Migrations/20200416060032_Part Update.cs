using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class PartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Portal",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Portal",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                schema: "Portal",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Portal",
                table: "Parts",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                schema: "Portal",
                table: "Locations",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                schema: "Portal",
                table: "Locations",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 6)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LocationId",
                schema: "Portal",
                table: "Parts",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Locations_LocationId",
                schema: "Portal",
                table: "Parts",
                column: "LocationId",
                principalSchema: "Portal",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Locations_LocationId",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_LocationId",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Portal",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Portal",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                schema: "Portal",
                table: "Locations",
                type: "decimal(2, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                schema: "Portal",
                table: "Locations",
                type: "decimal(2, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);
        }
    }
}
