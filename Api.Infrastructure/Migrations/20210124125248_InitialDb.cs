using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiplogs.Infrastructure.Migrations
{
    public partial class InitialDb : Migration
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
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                name: "WorkOrdersCompletedByDayForWeek",
                schema: "Portal",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: true),
                    TotalCompleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Lat = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    Long = table.Column<decimal>(type: "decimal(18, 6)", nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ImgFileName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true)
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
                    Id = table.Column<Guid>(nullable: false),
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
                    LocationId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ManufacuredDate = table.Column<DateTime>(nullable: true),
                    PurchasedDate = table.Column<DateTime>(nullable: true),
                    CurrentWorkDone = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    ImgFileName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    WarrantyUrl = table.Column<string>(nullable: true),
                    InstructionManualUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImgFileName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: false)
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkDone = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    DateCaptured = table.Column<DateTime>(nullable: true),
                    AssetId = table.Column<Guid>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AssetUsage_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenances",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AssetId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    DefaultTechnicianId = table.Column<Guid>(nullable: false),
                    TechnicianId = table.Column<Guid>(nullable: true),
                    DefaultTechnicianName = table.Column<string>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PlannedMaintenances_AspNetUsers_TechnicianId",
                        column: x => x.TechnicianId,
                        principalSchema: "Portal",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    HoursWorked = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    MintuesWorked = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TechnicianId = table.Column<Guid>(nullable: false),
                    TechnicianName = table.Column<string>(nullable: true),
                    AssetId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    IsPlanned = table.Column<bool>(nullable: false)
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
                        name: "FK_WorkOrders_AspNetUsers_TechnicianId",
                        column: x => x.TechnicianId,
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    PartId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceParts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "PlannedMaintenanceScheduleCustom",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: false),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    CycleNextDue = table.Column<decimal>(nullable: false),
                    StartingAt = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleCustom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleCustom_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleCustom_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleCustom_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleDaily",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: false),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleDaily_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleDaily_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleDaily_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleMonthly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: false),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    RecurrenceDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleMonthly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleMonthly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleMonthly_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleMonthly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleWeekly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: false),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleWeekly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleWeekly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleWeekly_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleWeekly_PlannedMaintenances_PlannedMaintenanceId",
                        column: x => x.PlannedMaintenanceId,
                        principalSchema: "Portal",
                        principalTable: "PlannedMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedMaintenanceScheduleYearly",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: false),
                    DateLastProcessed = table.Column<DateTime>(nullable: true),
                    DateNextDue = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    RecurEvery = table.Column<int>(nullable: false),
                    RecurrenceTime = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    RecurrenceMonth = table.Column<int>(nullable: false),
                    RecurrenceDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceScheduleYearly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleYearly_Asset_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "Portal",
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleYearly_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceScheduleYearly_PlannedMaintenances_PlannedMaintenanceId",
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PlannedMaintenanceId = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenanceTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenanceTasks_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkOrderId = table.Column<Guid>(nullable: false),
                    PartId = table.Column<Guid>(nullable: false),
                    QuantityRequired = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    QuantityUsed = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    WorkOrderId = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    QuantityRequired = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    QuantityUsed = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderTasks_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_AssetUsage_CompanyId",
                schema: "Portal",
                table: "AssetUsage",
                column: "CompanyId");

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
                name: "IX_PlannedMaintenanceParts_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceParts",
                column: "CompanyId");

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
                name: "IX_PlannedMaintenances_TechnicianId",
                schema: "Portal",
                table: "PlannedMaintenances",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleCustom_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleCustom",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleDaily_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleDaily",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleMonthly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleMonthly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleWeekly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleWeekly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_AssetId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceScheduleYearly_PlannedMaintenanceId",
                schema: "Portal",
                table: "PlannedMaintenanceScheduleYearly",
                column: "PlannedMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenanceTasks_CompanyId",
                schema: "Portal",
                table: "PlannedMaintenanceTasks",
                column: "CompanyId");

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
                name: "IX_WorkOrderParts_CompanyId",
                schema: "Portal",
                table: "WorkOrderParts",
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
                name: "IX_WorkOrders_TechnicianId",
                schema: "Portal",
                table: "WorkOrders",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderTasks_CompanyId",
                schema: "Portal",
                table: "WorkOrderTasks",
                column: "CompanyId");

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
                name: "PlannedMaintenanceScheduleCustom",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleDaily",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleMonthly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleWeekly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceScheduleYearly",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PlannedMaintenanceTasks",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "WorkOrderParts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "WorkOrdersCompletedByDayForWeek",
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
