using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class WOLinkedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleCustom",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ScheduleDaily",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ScheduleMonthly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ScheduleWeekly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ScheduleYearly",
                schema: "Portal");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetName",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "LocationName",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.CreateTable(
                name: "ScheduleCustom",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleNextDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastProcessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurEvery = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    StartingAt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleCustom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleCustom_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleCustom_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDaily",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastProcessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurEvery = table.Column<int>(type: "int", nullable: false),
                    RecurrenceTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDaily_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDaily_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleMonthly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastProcessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurEvery = table.Column<int>(type: "int", nullable: false),
                    RecurrenceDay = table.Column<int>(type: "int", nullable: false),
                    RecurrenceTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleMonthly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleMonthly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleMonthly_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleWeekly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastProcessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurEvery = table.Column<int>(type: "int", nullable: false),
                    RecurrenceTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleWeekly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleWeekly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleWeekly_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleYearly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastProcessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextDue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurEvery = table.Column<int>(type: "int", nullable: false),
                    RecurrenceDay = table.Column<int>(type: "int", nullable: false),
                    RecurrenceMonth = table.Column<int>(type: "int", nullable: false),
                    RecurrenceTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleYearly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleYearly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleYearly_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCustom_AssetId",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCustom_CompanyId",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleCustom_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDaily_AssetId",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDaily_CompanyId",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDaily_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleMonthly_AssetId",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleMonthly_CompanyId",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleMonthly_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWeekly_AssetId",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWeekly_CompanyId",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWeekly_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleYearly_AssetId",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleYearly_CompanyId",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleYearly_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "PlannedMaintenanceId");
        }
    }
}
