using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdatedDecimalColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interval",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "WorkOrderTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "WorkOrderTasks",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MintuesWorked",
                schema: "Portal",
                table: "WorkOrders",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HoursWorked",
                schema: "Portal",
                table: "WorkOrders",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "WorkOrderParts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "WorkOrderParts",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cycle",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                schema: "Portal",
                table: "PlannedMaintenances",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "WorkDone",
                schema: "Portal",
                table: "AssetUsage",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "UoM",
                schema: "Portal",
                table: "Asset",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentWorkDone",
                schema: "Portal",
                table: "Asset",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cycle",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "WorkOrderTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "WorkOrderTasks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MintuesWorked",
                schema: "Portal",
                table: "WorkOrders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HoursWorked",
                schema: "Portal",
                table: "WorkOrders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "WorkOrderParts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "WorkOrderParts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "Interval",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "WorkDone",
                schema: "Portal",
                table: "AssetUsage",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentWorkDone",
                schema: "Portal",
                table: "Asset",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");
        }
    }
}
