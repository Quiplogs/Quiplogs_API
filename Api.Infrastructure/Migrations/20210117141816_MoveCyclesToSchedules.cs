using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class MoveCyclesToSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cycles",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DefaultTechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTechnicianName",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EndDate",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom");

            migrationBuilder.DropColumn(
                name: "DefaultTechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "DefaultTechnicianName",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cycles",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
