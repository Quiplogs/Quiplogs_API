using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class AddEquipmentUsage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkDoneToday",
                schema: "Portal",
                table: "Equipment");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Portal",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "EquipmentUsage",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkDone = table.Column<decimal>(nullable: false),
                    DateCaptured = table.Column<DateTime>(nullable: true),
                    EquipmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentUsage_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Portal",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsage_EquipmentId",
                schema: "Portal",
                table: "EquipmentUsage",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentUsage",
                schema: "Portal");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                schema: "Portal",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkDoneToday",
                schema: "Portal",
                table: "Equipment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
