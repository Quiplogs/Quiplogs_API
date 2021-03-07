using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class RemoveLocationFromPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "LocationId",
                schema: "Portal",
                table: "Parts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                schema: "Portal",
                table: "Parts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
