using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class CorrectedWOtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderTasks_Tasks_TaskId",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderTasks_TaskId",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.DropColumn(
                name: "TaskId",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Portal",
                table: "WorkOrderTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Portal",
                table: "WorkOrderTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                schema: "Portal",
                table: "WorkOrderTasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderTasks_TaskId",
                schema: "Portal",
                table: "WorkOrderTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderTasks_Tasks_TaskId",
                schema: "Portal",
                table: "WorkOrderTasks",
                column: "TaskId",
                principalSchema: "Portal",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
