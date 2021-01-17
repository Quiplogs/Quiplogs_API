using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class PMSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleCustom",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    StartingAt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleCustom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleCustom_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleDaily",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleDaily_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleMonthly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurrenceDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleMonthly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleMonthly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleWeekly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleWeekly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleWeekly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleYearly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurrenceMonth = table.Column<int>(nullable: false),
                    RecurrenceDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleYearly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleYearly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrdersCompletedByDayForWeek",
                schema: "Portal",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: true),
                    TotalCompleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "PlannedMaintenanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleCustom",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleDaily",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleMonthly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleWeekly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleYearly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "WorkOrdersCompletedByDayForWeek",
                schema: "Portal");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
