using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class AddedTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UserId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropTable(
                name: "PartStock",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PreconParts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ServiceIntervalPart",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ServicePart",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PreconServiceIntervals",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PreconEquipment",
                schema: "Portal");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateToBeServiced",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "FaultNotes",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HoursWorked",
                schema: "Portal",
                table: "Services",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MechanicId",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsableUserId",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsableUserName",
                schema: "Portal",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                schema: "Portal",
                table: "ServiceIntervals",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                schema: "Portal",
                table: "Equipment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceIntervalParts",
                schema: "Portal",
                columns: table => new
                {
                    ServiceIntervalId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceIntervalParts", x => new { x.PartId, x.ServiceIntervalId });
                    table.ForeignKey(
                        name: "FK_ServiceIntervalParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceIntervalParts_ServiceIntervals_ServiceIntervalId",
                        column: x => x.ServiceIntervalId,
                        principalSchema: "Portal",
                        principalTable: "ServiceIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceParts",
                schema: "Portal",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PartCode = table.Column<string>(nullable: true),
                    PartDescription = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceParts", x => new { x.PartId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceParts_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Portal",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceIntervalTasks",
                schema: "Portal",
                columns: table => new
                {
                    ServiceIntervalId = table.Column<string>(nullable: false),
                    TaskId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceIntervalTasks", x => new { x.TaskId, x.ServiceIntervalId });
                    table.ForeignKey(
                        name: "FK_ServiceIntervalTasks_ServiceIntervals_ServiceIntervalId",
                        column: x => x.ServiceIntervalId,
                        principalSchema: "Portal",
                        principalTable: "ServiceIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceIntervalTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "Portal",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTasks",
                schema: "Portal",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    TaskId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    TaskDescription = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTasks", x => new { x.TaskId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceTasks_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Portal",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "Portal",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_LocationId",
                schema: "Portal",
                table: "Services",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_MechanicId",
                schema: "Portal",
                table: "Services",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ResponsableUserId",
                schema: "Portal",
                table: "Services",
                column: "ResponsableUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceIntervalParts_ServiceIntervalId",
                schema: "Portal",
                table: "ServiceIntervalParts",
                column: "ServiceIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceIntervalTasks_ServiceIntervalId",
                schema: "Portal",
                table: "ServiceIntervalTasks",
                column: "ServiceIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceParts_ServiceId",
                schema: "Portal",
                table: "ServiceParts",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTasks_ServiceId",
                schema: "Portal",
                table: "ServiceTasks",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CompanyId",
                schema: "Portal",
                table: "Tasks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Locations_LocationId",
                schema: "Portal",
                table: "Services",
                column: "LocationId",
                principalSchema: "Portal",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_MechanicId",
                schema: "Portal",
                table: "Services",
                column: "MechanicId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_ResponsableUserId",
                schema: "Portal",
                table: "Services",
                column: "ResponsableUserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Locations_LocationId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_MechanicId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_ResponsableUserId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceIntervalParts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ServiceIntervalTasks",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ServiceParts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ServiceTasks",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "Portal");

            migrationBuilder.DropIndex(
                name: "IX_Services_LocationId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_MechanicId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ResponsableUserId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FaultNotes",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MechanicName",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ResponsableUserId",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ResponsableUserName",
                schema: "Portal",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                schema: "Portal",
                table: "ServiceIntervals");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                schema: "Portal",
                table: "Equipment");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateToBeServiced",
                schema: "Portal",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Portal",
                table: "Services",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartStock",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PartId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartStock_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartStock_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartStock_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreconEquipment",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UoM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreconEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceIntervalPart",
                schema: "Portal",
                columns: table => new
                {
                    PartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceIntervalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceIntervalPart", x => new { x.PartId, x.ServiceIntervalId });
                    table.ForeignKey(
                        name: "FK_ServiceIntervalPart_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceIntervalPart_ServiceIntervals_ServiceIntervalId",
                        column: x => x.ServiceIntervalId,
                        principalSchema: "Portal",
                        principalTable: "ServiceIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicePart",
                schema: "Portal",
                columns: table => new
                {
                    PartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePart", x => new { x.PartId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ServicePart_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicePart_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Portal",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreconServiceIntervals",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Interval = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreconEquipmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UoM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreconServiceIntervals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreconServiceIntervals_PreconEquipment_PreconEquipmentId",
                        column: x => x.PreconEquipmentId,
                        principalSchema: "Portal",
                        principalTable: "PreconEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreconParts",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreconServiceIntervalDtoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreconParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreconParts_PreconServiceIntervals_PreconServiceIntervalDtoId",
                        column: x => x.PreconServiceIntervalDtoId,
                        principalSchema: "Portal",
                        principalTable: "PreconServiceIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                schema: "Portal",
                table: "Services",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartStock_CompanyId",
                schema: "Portal",
                table: "PartStock",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartStock_LocationId",
                schema: "Portal",
                table: "PartStock",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartStock_PartId",
                schema: "Portal",
                table: "PartStock",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PreconParts_PreconServiceIntervalDtoId",
                schema: "Portal",
                table: "PreconParts",
                column: "PreconServiceIntervalDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_PreconServiceIntervals_PreconEquipmentId",
                schema: "Portal",
                table: "PreconServiceIntervals",
                column: "PreconEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceIntervalPart_ServiceIntervalId",
                schema: "Portal",
                table: "ServiceIntervalPart",
                column: "ServiceIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePart_ServiceId",
                schema: "Portal",
                table: "ServicePart",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_UserId",
                schema: "Portal",
                table: "Services",
                column: "UserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
