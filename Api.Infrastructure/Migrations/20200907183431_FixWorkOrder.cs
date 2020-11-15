using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class FixWorkOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_MechanicId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_MechanicId",
                schema: "Portal",
                table: "WorkOrders");

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

            migrationBuilder.DropColumn(
                name: "MechanicId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianId",
                schema: "Portal",
                table: "WorkOrders",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_TechnicianId",
                schema: "Portal",
                table: "WorkOrders",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_TechnicianId",
                schema: "Portal",
                table: "WorkOrders",
                column: "TechnicianId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_TechnicianId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_TechnicianId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianId",
                schema: "Portal",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InBusy",
                schema: "Portal",
                table: "WorkOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                schema: "Portal",
                table: "WorkOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                schema: "Portal",
                table: "WorkOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                schema: "Portal",
                table: "WorkOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MechanicId",
                schema: "Portal",
                table: "WorkOrders",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_MechanicId",
                schema: "Portal",
                table: "WorkOrders",
                column: "MechanicId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
