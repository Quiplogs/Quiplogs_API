using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class AddImageProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaultNotes",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MechanicName",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "BuildYear",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portal",
                table: "WorkOrderTasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portal",
                table: "WorkOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MintuesWorked",
                schema: "Portal",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portal",
                table: "WorkOrderParts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                schema: "Portal",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                schema: "Portal",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                schema: "Portal",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                schema: "Portal",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoFileName",
                schema: "Portal",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                schema: "Portal",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructionManualUrl",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacuredYear",
                schema: "Portal",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchasedYear",
                schema: "Portal",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarrantyUrl",
                schema: "Portal",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenances_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenances_LocationId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenances_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "CompanyId",
                principalSchema: "Portal",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedMaintenances_Locations_LocationId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "LocationId",
                principalSchema: "Portal",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenances_Companies_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedMaintenances_Locations_LocationId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropIndex(
                name: "IX_PlannedMaintenances_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropIndex(
                name: "IX_PlannedMaintenances_LocationId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MintuesWorked",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "TechnicianName",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portal",
                table: "WorkOrderParts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portal",
                table: "PlannedMaintenanceTasks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Portal",
                table: "PlannedMaintenanceParts");

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
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LogoFileName",
                schema: "Portal",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                schema: "Portal",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ImgFileName",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "InstructionManualUrl",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ManufacuredYear",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "PurchasedYear",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "WarrantyUrl",
                schema: "Portal",
                table: "Asset");

            migrationBuilder.AddColumn<string>(
                name: "FaultNotes",
                schema: "Portal",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                schema: "Portal",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BuildYear",
                schema: "Portal",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
