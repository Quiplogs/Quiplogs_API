using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class AlterAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacuredYear",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "PurchasedYear",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.AddColumn<DateTime>(
                name: "ManufacuredDate",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedDate",
                schema: "Portal",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacuredDate",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "PurchasedDate",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "ManufacuredYear",
                schema: "Portal",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchasedYear",
                schema: "Portal",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
