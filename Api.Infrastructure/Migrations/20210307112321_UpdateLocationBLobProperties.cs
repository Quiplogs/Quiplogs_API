using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdateLocationBLobProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgFileName",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                schema: "Portal",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Portal",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                schema: "Portal",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                schema: "Portal",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
