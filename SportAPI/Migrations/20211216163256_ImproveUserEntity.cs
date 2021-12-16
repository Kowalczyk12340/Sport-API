using Microsoft.EntityFrameworkCore.Migrations;

namespace SportAPI.Migrations
{
    public partial class ImproveUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId1",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId1",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                schema: "Sport",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                schema: "Sport",
                table: "User",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "Sport",
                table: "User",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "Sport",
                table: "User",
                column: "RoleId",
                principalSchema: "Sport",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "Sport",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                schema: "Sport",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                schema: "Sport",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                schema: "Sport",
                table: "User",
                type: "bigint",
                nullable: true);

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
    }
}
