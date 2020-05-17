using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Portal");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    SubscriptionId = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    LockedReason = table.Column<string>(nullable: true),
                    LogoFileName = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Portal",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
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
                name: "AspNetUserRoles",
                schema: "Portal",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Portal",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Portal",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Portal",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Lat = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Long = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ImgFileName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ManufacuredYear = table.Column<int>(nullable: false),
                    PurchasedYear = table.Column<int>(nullable: false),
                    CurrentWorkDone = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    ImgFileName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    WarrantyUrl = table.Column<string>(nullable: true),
                    InstructionManualUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImgFileName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetUsage",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkDone = table.Column<decimal>(nullable: false),
                    DateCaptured = table.Column<DateTime>(nullable: true),
                    AssetId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetUsage_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenances",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    AssetId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    Interval = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UoM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenances_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenances_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenances_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    HoursWorked = table.Column<decimal>(nullable: false),
                    MintuesWorked = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TechnicianId = table.Column<string>(nullable: true),
                    MechanicId = table.Column<string>(nullable: true),
                    TechnicianName = table.Column<string>(nullable: true),
                    ResponsableUserId = table.Column<string>(nullable: true),
                    ResponsableUserName = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_MechanicId",
                        column: x => x.MechanicId,
                        principalSchema: "Portal",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_AspNetUsers_ResponsableUserId",
                        column: x => x.ResponsableUserId,
                        principalSchema: "Portal",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceParts",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    PartId = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceParts_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceTasks",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<string>(nullable: true),
                    TaskId = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceTasks_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "Portal",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderParts",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkOrderId = table.Column<string>(nullable: true),
                    PartId = table.Column<string>(nullable: true),
                    PartCode = table.Column<string>(nullable: true),
                    PartDescription = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "Portal",
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalSchema: "Portal",
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTasks",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkOrderId = table.Column<string>(nullable: true),
                    TaskId = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "Portal",
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderTasks_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalSchema: "Portal",
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Portal",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Portal",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Portal",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Portal",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Portal",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                schema: "Portal",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                schema: "Portal",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Portal",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Portal",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CompanyId",
                schema: "Portal",
                table: "Asset",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LocationId",
                schema: "Portal",
                table: "Asset",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetUsage_AssetId",
                schema: "Portal",
                table: "AssetUsage",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CompanyId",
                schema: "Portal",
                table: "Locations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                schema: "Portal",
                table: "Locations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CompanyId",
                schema: "Portal",
                table: "Parts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LocationId",
                schema: "Portal",
                table: "Parts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceParts_PartId",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceParts_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenances_AssetId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "AssetId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceTasks_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceTasks_TaskId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CompanyId",
                schema: "Portal",
                table: "Tasks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_PartId",
                schema: "Portal",
                table: "WorkOrderParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_WorkOrderId",
                schema: "Portal",
                table: "WorkOrderParts",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssetId",
                schema: "Portal",
                table: "WorkOrders",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CompanyId",
                schema: "Portal",
                table: "WorkOrders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_LocationId",
                schema: "Portal",
                table: "WorkOrders",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MechanicId",
                schema: "Portal",
                table: "WorkOrders",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_ResponsableUserId",
                schema: "Portal",
                table: "WorkOrders",
                column: "ResponsableUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderTasks_TaskId",
                schema: "Portal",
                table: "WorkOrderTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderTasks_WorkOrderId",
                schema: "Portal",
                table: "WorkOrderTasks",
                column: "WorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Portal",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Portal",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Portal",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Portal",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_UserId",
                schema: "Portal",
                table: "Locations",
                column: "UserId",
                principalSchema: "Portal",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_UserId",
                schema: "Portal",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AssetUsage",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceParts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceTasks",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "WorkOrderParts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "WorkOrderTasks",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenances",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Parts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "WorkOrders",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Asset",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Portal");
        }
    }
}
