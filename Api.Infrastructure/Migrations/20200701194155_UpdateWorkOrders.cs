using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdateWorkOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDescription",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.DropColumn(
                name: "PartCode",
                schema: "Portal",
                table: "WorkOrderParts");

            migrationBuilder.DropColumn(
                name: "PartDescription",
                schema: "Portal",
                table: "WorkOrderParts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "Portal",
                table: "WorkOrderTasks",
                newName: "QuantityUsed");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "Portal",
                table: "WorkOrderParts",
                newName: "QuantityUsed");

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityRequired",
                schema: "Portal",
                table: "WorkOrderTasks",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityRequired",
                schema: "Portal",
                table: "WorkOrderParts",
                type: "decimal(18, 6)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityRequired",
                schema: "Portal",
                table: "WorkOrderTasks");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "QuantityRequired",
                schema: "Portal",
                table: "WorkOrderParts");

            migrationBuilder.RenameColumn(
                name: "QuantityUsed",
                schema: "Portal",
                table: "WorkOrderTasks",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "QuantityUsed",
                schema: "Portal",
                table: "WorkOrderParts",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "TaskDescription",
                schema: "Portal",
                table: "WorkOrderTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartCode",
                schema: "Portal",
                table: "WorkOrderParts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartDescription",
                schema: "Portal",
                table: "WorkOrderParts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
