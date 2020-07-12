using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class AddedStatusChecktoWO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InBusy",
                schema: "Portal",
                table: "WorkOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                schema: "Portal",
                table: "WorkOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                schema: "Portal",
                table: "WorkOrders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InBusy",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                schema: "Portal",
                table: "WorkOrders");
        }
    }
}
