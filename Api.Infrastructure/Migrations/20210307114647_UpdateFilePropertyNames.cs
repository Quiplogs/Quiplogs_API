using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdateFilePropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgFileName",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                schema: "Portal",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ImgFileName",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                schema: "Portal",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Portal",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Portal",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                schema: "Portal",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                schema: "Portal",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
