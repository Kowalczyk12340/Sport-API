using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportAPI.Migrations
{
    public partial class RolesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "Sport",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "Sport",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                schema: "Sport",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId1",
                schema: "Sport",
                table: "User",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId1",
                schema: "Sport",
                table: "User",
                column: "RoleId1",
                principalSchema: "Sport",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId1",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Sport");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId1",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                schema: "Sport",
                table: "User");
        }
    }
}
