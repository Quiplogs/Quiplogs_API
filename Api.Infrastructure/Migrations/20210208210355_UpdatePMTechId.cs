using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdatePMTechId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenances_AspNetUsers_TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropIndex(
                name: "IX_PlannedMaintenances_TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenances_DefaultTechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "DefaultTechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenances_AspNetUsers_DefaultTechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "DefaultTechnicianId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenances_AspNetUsers_DefaultTechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropIndex(
                name: "IX_PlannedMaintenances_DefaultTechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.AddColumn<Guid>(
                name: "TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenances_TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenances_AspNetUsers_TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "TechnicianId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
