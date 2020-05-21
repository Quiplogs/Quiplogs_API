using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class CorrectColumnSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cycle",
                schema: "Portal",
                table: "PlannedMaintenances",
                newName: "Cycles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cycles",
                schema: "Portal",
                table: "PlannedMaintenances",
                newName: "Cycle");
        }
    }
}
