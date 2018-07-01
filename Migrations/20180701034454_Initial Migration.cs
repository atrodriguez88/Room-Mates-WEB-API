using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomM.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
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
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    ShowPhone = table.Column<bool>(nullable: false),
                    NotificationViaEmail = table.Column<bool>(nullable: false),
                    AboutMe = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ProfilesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocupations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
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
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
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
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
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
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFeatures",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyFeatures_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyFeatures_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyFeatures_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyRules",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyRules_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyRules_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyRules_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyTypes_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomFeatures",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFeatures_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomFeatures_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomFeatures_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrefGender = table.Column<string>(nullable: true),
                    PrefMinAge = table.Column<int>(nullable: false),
                    PrefMaxAge = table.Column<int>(nullable: false),
                    AdTitle = table.Column<string>(maxLength: 100, nullable: true),
                    AdDescription = table.Column<string>(maxLength: 255, nullable: true),
                    OcupationId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preferences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Preferences_Ocupations_OcupationId",
                        column: x => x.OcupationId,
                        principalTable: "Ocupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    OcupationId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    MaxRentMonth = table.Column<string>(nullable: false),
                    MovingDate = table.Column<DateTime>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_Ocupations_OcupationId",
                        column: x => x.OcupationId,
                        principalTable: "Ocupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    PropertyTypeId = table.Column<int>(nullable: true),
                    NumberBedrooms = table.Column<int>(nullable: false),
                    NumberBathrooms = table.Column<int>(nullable: false),
                    RoomsToRent = table.Column<int>(nullable: false),
                    RentPerMonth = table.Column<float>(nullable: false),
                    IsUtilityIncluded = table.Column<bool>(nullable: false),
                    RoomType = table.Column<string>(maxLength: 50, nullable: false),
                    RoomSquareMeters = table.Column<float>(nullable: false),
                    IsFurnished = table.Column<bool>(nullable: false),
                    AvailableFrom = table.Column<DateTime>(nullable: false),
                    MinStayMonths = table.Column<int>(nullable: false),
                    Smoking = table.Column<string>(nullable: true),
                    Pet = table.Column<string>(nullable: true),
                    Cleanliness = table.Column<string>(nullable: true),
                    NumberRoomatesAlready = table.Column<int>(nullable: false),
                    PreferenceId = table.Column<int>(nullable: false),
                    PreferenceId1 = table.Column<int>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Preferences_PreferenceId1",
                        column: x => x.PreferenceId1,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomRoomFeatures",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    RoomFeaturesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRoomFeatures", x => new { x.RoomId, x.RoomFeaturesId });
                    table.ForeignKey(
                        name: "FK_RoomRoomFeatures_RoomFeatures_RoomFeaturesId",
                        column: x => x.RoomFeaturesId,
                        principalTable: "RoomFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRoomFeatures_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsPropertyFeatures",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    PropertyFeaturesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsPropertyFeatures", x => new { x.RoomId, x.PropertyFeaturesId });
                    table.ForeignKey(
                        name: "FK_RoomsPropertyFeatures_PropertyFeatures_PropertyFeaturesId",
                        column: x => x.PropertyFeaturesId,
                        principalTable: "PropertyFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsPropertyFeatures_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsPropertyRules",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    PropertyRulesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsPropertyRules", x => new { x.RoomId, x.PropertyRulesId });
                    table.ForeignKey(
                        name: "FK_RoomsPropertyRules_PropertyRules_PropertyRulesId",
                        column: x => x.PropertyRulesId,
                        principalTable: "PropertyRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsPropertyRules_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_CreatedBy",
                table: "Preferences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_DeletedBy",
                table: "Preferences",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_OcupationId",
                table: "Preferences",
                column: "OcupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UpdatedBy",
                table: "Preferences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CreatedBy",
                table: "Profiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DeletedBy",
                table: "Profiles",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OcupationId",
                table: "Profiles",
                column: "OcupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UpdatedBy",
                table: "Profiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId1",
                table: "Profiles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_CreatedBy",
                table: "PropertyFeatures",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_DeletedBy",
                table: "PropertyFeatures",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_UpdatedBy",
                table: "PropertyFeatures",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRules_CreatedBy",
                table: "PropertyRules",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRules_DeletedBy",
                table: "PropertyRules",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRules_UpdatedBy",
                table: "PropertyRules",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_CreatedBy",
                table: "PropertyTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_DeletedBy",
                table: "PropertyTypes",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_UpdatedBy",
                table: "PropertyTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_CreatedBy",
                table: "RoomFeatures",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_DeletedBy",
                table: "RoomFeatures",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_UpdatedBy",
                table: "RoomFeatures",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRoomFeatures_RoomFeaturesId",
                table: "RoomRoomFeatures",
                column: "RoomFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatedBy",
                table: "Rooms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DeletedBy",
                table: "Rooms",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PreferenceId1",
                table: "Rooms",
                column: "PreferenceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ProfileId",
                table: "Rooms",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PropertyTypeId",
                table: "Rooms",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UpdatedBy",
                table: "Rooms",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsPropertyFeatures_PropertyFeaturesId",
                table: "RoomsPropertyFeatures",
                column: "PropertyFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsPropertyRules_PropertyRulesId",
                table: "RoomsPropertyRules",
                column: "PropertyRulesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RoomRoomFeatures");

            migrationBuilder.DropTable(
                name: "RoomsPropertyFeatures");

            migrationBuilder.DropTable(
                name: "RoomsPropertyRules");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RoomFeatures");

            migrationBuilder.DropTable(
                name: "PropertyFeatures");

            migrationBuilder.DropTable(
                name: "PropertyRules");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Ocupations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
