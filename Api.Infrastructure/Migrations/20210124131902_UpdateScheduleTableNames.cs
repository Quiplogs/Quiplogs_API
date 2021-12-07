using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdateScheduleTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleCustom_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleCustom_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleDaily_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleDaily_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleMonthly_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleMonthly_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleWeekly_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleWeekly_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleYearly_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleYearly_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenanceScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleYearly",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleWeekly",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleMonthly",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleDaily",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleCustom",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom");

            migrationBuilder.RenameTable(
                name: "PlannedMaintenanceScheduleYearly",
                schema: "Portal",
                newName: "ScheduleYearly",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "PlannedMaintenanceScheduleWeekly",
                schema: "Portal",
                newName: "ScheduleWeekly",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "PlannedMaintenanceScheduleMonthly",
                schema: "Portal",
                newName: "ScheduleMonthly",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "PlannedMaintenanceScheduleDaily",
                schema: "Portal",
                newName: "ScheduleDaily",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "PlannedMaintenanceScheduleCustom",
                schema: "Portal",
                newName: "ScheduleCustom",
                newSchema: "Portal");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleYearly",
                newName: "IX_ScheduleYearly_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_CompanyId",
                schema: "Portal",
                table: "ScheduleYearly",
                newName: "IX_ScheduleYearly_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_AssetId",
                schema: "Portal",
                table: "ScheduleYearly",
                newName: "IX_ScheduleYearly_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleWeekly",
                newName: "IX_ScheduleWeekly_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_CompanyId",
                schema: "Portal",
                table: "ScheduleWeekly",
                newName: "IX_ScheduleWeekly_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_AssetId",
                schema: "Portal",
                table: "ScheduleWeekly",
                newName: "IX_ScheduleWeekly_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleMonthly",
                newName: "IX_ScheduleMonthly_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_CompanyId",
                schema: "Portal",
                table: "ScheduleMonthly",
                newName: "IX_ScheduleMonthly_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_AssetId",
                schema: "Portal",
                table: "ScheduleMonthly",
                newName: "IX_ScheduleMonthly_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleDaily",
                newName: "IX_ScheduleDaily_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_CompanyId",
                schema: "Portal",
                table: "ScheduleDaily",
                newName: "IX_ScheduleDaily_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_AssetId",
                schema: "Portal",
                table: "ScheduleDaily",
                newName: "IX_ScheduleDaily_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleCustom",
                newName: "IX_ScheduleCustom_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_CompanyId",
                schema: "Portal",
                table: "ScheduleCustom",
                newName: "IX_ScheduleCustom_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_AssetId",
                schema: "Portal",
                table: "ScheduleCustom",
                newName: "IX_ScheduleCustom_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleYearly",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleWeekly",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleMonthly",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleDaily",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleCustom",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleCustom_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleCustom_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleCustom",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDaily_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDaily_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleDaily",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleMonthly_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleMonthly_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleMonthly",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleWeekly_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleWeekly_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleWeekly",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleYearly_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleYearly_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleYearly",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleCustom_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleCustom");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleCustom_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleCustom");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleCustom");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDaily_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleDaily");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDaily_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleDaily");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleDaily");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleMonthly_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleMonthly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleMonthly_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleMonthly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleMonthly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleWeekly_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleWeekly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleWeekly_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleWeekly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleWeekly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleYearly_Asset_AssetId",
                schema: "Portal",
                table: "ScheduleYearly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleYearly_Companies_CompanyId",
                schema: "Portal",
                table: "ScheduleYearly");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "ScheduleYearly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleYearly",
                schema: "Portal",
                table: "ScheduleYearly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleWeekly",
                schema: "Portal",
                table: "ScheduleWeekly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleMonthly",
                schema: "Portal",
                table: "ScheduleMonthly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleDaily",
                schema: "Portal",
                table: "ScheduleDaily");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleCustom",
                schema: "Portal",
                table: "ScheduleCustom");

            migrationBuilder.RenameTable(
                name: "ScheduleYearly",
                schema: "Portal",
                newName: "PlannedMaintenanceScheduleYearly",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "ScheduleWeekly",
                schema: "Portal",
                newName: "PlannedMaintenanceScheduleWeekly",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "ScheduleMonthly",
                schema: "Portal",
                newName: "PlannedMaintenanceScheduleMonthly",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "ScheduleDaily",
                schema: "Portal",
                newName: "PlannedMaintenanceScheduleDaily",
                newSchema: "Portal");

            migrationBuilder.RenameTable(
                name: "ScheduleCustom",
                schema: "Portal",
                newName: "PlannedMaintenanceScheduleCustom",
                newSchema: "Portal");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleYearly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                newName: "IX_PlannedMaintenanceScheduleYearly_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleYearly_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                newName: "IX_PlannedMaintenanceScheduleYearly_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleYearly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                newName: "IX_PlannedMaintenanceScheduleYearly_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleWeekly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                newName: "IX_PlannedMaintenanceScheduleWeekly_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleWeekly_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                newName: "IX_PlannedMaintenanceScheduleWeekly_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleWeekly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                newName: "IX_PlannedMaintenanceScheduleWeekly_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleMonthly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                newName: "IX_PlannedMaintenanceScheduleMonthly_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleMonthly_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                newName: "IX_PlannedMaintenanceScheduleMonthly_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleMonthly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                newName: "IX_PlannedMaintenanceScheduleMonthly_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleDaily_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                newName: "IX_PlannedMaintenanceScheduleDaily_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleDaily_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                newName: "IX_PlannedMaintenanceScheduleDaily_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleDaily_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                newName: "IX_PlannedMaintenanceScheduleDaily_AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleCustom_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                newName: "IX_PlannedMaintenanceScheduleCustom_PlannedMaintenanceId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleCustom_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                newName: "IX_PlannedMaintenanceScheduleCustom_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleCustom_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                newName: "IX_PlannedMaintenanceScheduleCustom_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleYearly",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleWeekly",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleMonthly",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleDaily",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedMaintenanceScheduleCustom",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleCustom_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleCustom_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleDaily_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleDaily_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleMonthly_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleMonthly_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleWeekly_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleWeekly_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleYearly_Asset_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "AssetId",
                principalSchema: "Portal",
                principalTable: "Asset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleYearly_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenanceScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "PlannedMaintenanceId",
                principalSchema: "Portal",
                principalTable: "PlannedMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
