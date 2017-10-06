using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetCoreVue.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LoginUserName = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_UserInfoId", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseAbbreviation = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    CourseName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CourseId", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_UserInfo_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_UserInfo_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_UserInfo_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    CustomerAccountId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Comments = table.Column<string>(type: "NVARCHAR(4000)", maxLength: 4000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CustomerAccountId", x => x.CustomerAccountId);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_UserInfo_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_UserInfo_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionSynopses",
                columns: table => new
                {
                    SessionSynopsisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SessionSynopsisName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_SessionSynopsisId", x => x.SessionSynopsisId);
                    table.ForeignKey(
                        name: "FK_SessionSynopses_UserInfo_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionSynopses_UserInfo_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    TimeSheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedById = table.Column<int>(type: "int", nullable: false),
                    CheckedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    MonthAndYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatePerHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    VerifiedAndSubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_TimeSheetId", x => x.TimeSheetId);
                    table.ForeignKey(
                        name: "FK_TimeSheets_UserInfo_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSheets_UserInfo_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSheets_UserInfo_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheets_UserInfo_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountDetails",
                columns: table => new
                {
                    AccountDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerAccountId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeekNumber = table.Column<int>(type: "int", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StartTimeInMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_AccountDetailId", x => x.AccountDetailId);
                    table.ForeignKey(
                        name: "FK_AccountDetails_CustomerAccounts_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "CustomerAccounts",
                        principalColumn: "CustomerAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRates",
                columns: table => new
                {
                    AccountRateId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerAccountId = table.Column<int>(type: "int", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatePerHour = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_AccountRateId", x => x.AccountRateId);
                    table.ForeignKey(
                        name: "FK_AccountRates_CustomerAccounts_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "CustomerAccounts",
                        principalColumn: "CustomerAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorAccounts",
                columns: table => new
                {
                    InstructorAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "NVARCHAR(4000)", nullable: true),
                    CustomerAccountId = table.Column<int>(type: "int", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    WageRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_InstructorAccounttId", x => x.InstructorAccountId);
                    table.ForeignKey(
                        name: "FK_InstructorAccounts_CustomerAccounts_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "CustomerAccounts",
                        principalColumn: "CustomerAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorAccounts_UserInfo_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "UserInfo",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetDetails",
                columns: table => new
                {
                    TimeSheetDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountDetailId = table.Column<int>(type: "int", nullable: false),
                    DateOfLesson = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReplacementInstructor = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OfficialTimeInMinutes = table.Column<int>(type: "int", nullable: false),
                    OfficialTimeOutMinutes = table.Column<int>(type: "int", nullable: false),
                    SessionSynopsisNames = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    TimeInInMinutes = table.Column<int>(type: "int", nullable: false),
                    TimeOutInMinutes = table.Column<int>(type: "int", nullable: false),
                    TimeSheetId = table.Column<int>(type: "int", nullable: false),
                    WageRatePerHour = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_TimeSheetDetailId", x => x.TimeSheetDetailId);
                    table.ForeignKey(
                        name: "FK_TimeSheetDetails_AccountDetails_AccountDetailId",
                        column: x => x.AccountDetailId,
                        principalTable: "AccountDetails",
                        principalColumn: "AccountDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheetDetails_TimeSheets_TimeSheetId",
                        column: x => x.TimeSheetId,
                        principalTable: "TimeSheets",
                        principalColumn: "TimeSheetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetDetailSignature",
                columns: table => new
                {
                    TimeSheetDetailSignatureId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Signature = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: true),
                    TimeSheetIDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_TimeSheetSignatureId", x => x.TimeSheetDetailSignatureId);
                    table.ForeignKey(
                        name: "FK_TimeSheetDetailSignature_TimeSheetDetails_TimeSheetIDetailId",
                        column: x => x.TimeSheetIDetailId,
                        principalTable: "TimeSheetDetails",
                        principalColumn: "TimeSheetDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_CustomerAccountId",
                table: "AccountDetails",
                column: "CustomerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRates_CustomerAccountId",
                table: "AccountRates",
                column: "CustomerAccountId");

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
                name: "Course_CourseAbbreviation_UniqueConstraint",
                table: "Courses",
                column: "CourseAbbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedById",
                table: "Courses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeletedById",
                table: "Courses",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UpdatedById",
                table: "Courses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "CustomerAccount_AccountName_UniqueConstraint",
                table: "CustomerAccounts",
                column: "AccountName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CreatedById",
                table: "CustomerAccounts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_UpdatedById",
                table: "CustomerAccounts",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAccounts_CustomerAccountId",
                table: "InstructorAccounts",
                column: "CustomerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAccounts_InstructorId",
                table: "InstructorAccounts",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSynopses_CreatedById",
                table: "SessionSynopses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "SessionSynopsis_SessionSynopsisName_UniqueConstraint",
                table: "SessionSynopses",
                column: "SessionSynopsisName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionSynopses_UpdatedById",
                table: "SessionSynopses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetDetails_AccountDetailId",
                table: "TimeSheetDetails",
                column: "AccountDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetDetails_TimeSheetId",
                table: "TimeSheetDetails",
                column: "TimeSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetDetailSignature_TimeSheetIDetailId",
                table: "TimeSheetDetailSignature",
                column: "TimeSheetIDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_ApprovedById",
                table: "TimeSheets",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_CreatedById",
                table: "TimeSheets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_InstructorId",
                table: "TimeSheets",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_UpdatedById",
                table: "TimeSheets",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "UserInfo_LoginUserName_UniqueConstraint",
                table: "UserInfo",
                column: "LoginUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRates");

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
                name: "Courses");

            migrationBuilder.DropTable(
                name: "InstructorAccounts");

            migrationBuilder.DropTable(
                name: "SessionSynopses");

            migrationBuilder.DropTable(
                name: "TimeSheetDetailSignature");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TimeSheetDetails");

            migrationBuilder.DropTable(
                name: "AccountDetails");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
