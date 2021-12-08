using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportAPI.Migrations
{
    public partial class ImproveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sport");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthToken",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    InfomationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportClub",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportClubName = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    HasOwnStadium = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "'1'"),
                    ContactEmail = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportClub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportClub_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Sport",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportClub_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Sport",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportClubId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coach_SportClub_SportClubId",
                        column: x => x.SportClubId,
                        principalSchema: "Sport",
                        principalTable: "SportClub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamOne = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    TeamTwo = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    InHouse = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "'1'"),
                    DateOfMatch = table.Column<DateTime>(type: "DateTime", nullable: false),
                    SportClubId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_SportClub_SportClubId",
                        column: x => x.SportClubId,
                        principalSchema: "Sport",
                        principalTable: "SportClub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BetterFoot = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(115)", maxLength: 115, nullable: false),
                    SportClubId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_SportClub_SportClubId",
                        column: x => x.SportClubId,
                        principalSchema: "Sport",
                        principalTable: "SportClub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfTraining = table.Column<DateTime>(type: "DateTime", nullable: false),
                    SportClubId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_SportClub_SportClubId",
                        column: x => x.SportClubId,
                        principalSchema: "Sport",
                        principalTable: "SportClub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coach_SportClubId",
                schema: "Sport",
                table: "Coach",
                column: "SportClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_SportClubId",
                schema: "Sport",
                table: "Match",
                column: "SportClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_SportClubId",
                schema: "Sport",
                table: "Player",
                column: "SportClubId");

            migrationBuilder.CreateIndex(
                name: "IX_SportClub_AddressId",
                schema: "Sport",
                table: "SportClub",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportClub_UserId",
                schema: "Sport",
                table: "SportClub",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Training_SportClubId",
                schema: "Sport",
                table: "Training",
                column: "SportClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthToken",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "Coach",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "Match",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "Training",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "SportClub",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Sport");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Sport");
        }
    }
}
