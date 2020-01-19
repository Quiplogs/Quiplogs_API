using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class InitialDBDesign : Migration
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
                    LockedReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreconEquipment",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    UoM = table.Column<string>(nullable: true),
                    IsReviewed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreconEquipment", x => x.Id);
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
                name: "Parts",
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
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreconServiceIntervals",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PreconEquipmentId = table.Column<string>(nullable: true),
                    Interval = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true)
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
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PreconServiceIntervalDtoId = table.Column<string>(nullable: true)
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
                    Name = table.Column<int>(nullable: false),
                    Lat = table.Column<long>(nullable: true),
                    Long = table.Column<long>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
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
                name: "Equipment",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    BuildYear = table.Column<int>(nullable: false),
                    CurrentWorkDone = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    WorkDoneToday = table.Column<decimal>(nullable: false),
                    LocationId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Portal",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartStock",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    PartId = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
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
                name: "ServiceIntervals",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    EquipmentId = table.Column<string>(nullable: true),
                    Interval = table.Column<decimal>(nullable: false),
                    UoM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceIntervals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceIntervals_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Portal",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    DateToBeServiced = table.Column<DateTime>(nullable: true),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EquipmentId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Portal",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalSchema: "Portal",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Portal",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceIntervalPart",
                schema: "Portal",
                columns: table => new
                {
                    ServiceIntervalId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
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
                    ServiceId = table.Column<string>(nullable: false),
                    PartId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    DateCompleted = table.Column<DateTime>(nullable: false)
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
                name: "IX_Equipment_CompanyId",
                schema: "Portal",
                table: "Equipment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_LocationId",
                schema: "Portal",
                table: "Equipment",
                column: "LocationId");

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
                name: "IX_ServiceIntervals_EquipmentId",
                schema: "Portal",
                table: "ServiceIntervals",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePart_ServiceId",
                schema: "Portal",
                table: "ServicePart",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CompanyId",
                schema: "Portal",
                table: "Services",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EquipmentId",
                schema: "Portal",
                table: "Services",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                schema: "Portal",
                table: "Services",
                column: "UserId");

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
                name: "AspNetRoles",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PreconServiceIntervals",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "ServiceIntervals",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Parts",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "PreconEquipment",
                schema: "Portal");

            migrationBuilder.DropTable(
                name: "Equipment",
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
