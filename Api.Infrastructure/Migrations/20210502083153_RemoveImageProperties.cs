using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class RemoveImageProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LogoFileName",
                schema: "Portal",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                schema: "Portal",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "InstructionManualUrl",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "WarrantyUrl",
                schema: "Portal",
                table: "Asset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                schema: "Portal",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Portal",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                schema: "Portal",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Portal",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoFileName",
                schema: "Portal",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                schema: "Portal",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructionManualUrl",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarrantyUrl",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
