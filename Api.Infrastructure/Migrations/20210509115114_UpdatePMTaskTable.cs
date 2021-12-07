using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdatePMTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceTasks_Tasks_TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks");

            migrationBuilder.DropIndex(
                name: "IX_PlannedMaintenanceTasks_TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks");

            migrationBuilder.DropColumn(
                name: "TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks");

            migrationBuilder.RenameColumn(
                name: "MintuesWorked",
                schema: "Portal",
                table: "WorkOrders",
                newName: "MinutesWorked");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                newName: "QuantityRequired");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Portal",
                table: "PlannedMaintenanceTasks");

            migrationBuilder.RenameColumn(
                name: "MinutesWorked",
                schema: "Portal",
                table: "WorkOrders",
                newName: "MintuesWorked");

            migrationBuilder.RenameColumn(
                name: "QuantityRequired",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                newName: "Quantity");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceTasks_TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceTasks_Tasks_TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                column: "TaskId",
                principalSchema: "Portal",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
