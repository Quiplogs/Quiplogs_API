using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class UpdatePM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultTechnicianName",
                schema: "Portal",
                table: "PlannedMaintenances");

            migrationBuilder.DropColumn(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultTechnicianName",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UoM",
                schema: "Portal",
                table: "PlannedMaintenances",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
