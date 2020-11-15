using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class AddPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_AspNetUsers_ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ResponsableUserName",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "Portal",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "Portal",
                table: "WorkOrders");

            migrationBuilder.AddColumn<string>(
                name: "ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsableUserName",
                schema: "Portal",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders",
                column: "ResponsableUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_AspNetUsers_ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders",
                column: "ResponsableUserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
