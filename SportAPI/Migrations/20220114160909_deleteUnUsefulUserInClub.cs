using Microsoft.EntityFrameworkCore.Migrations;

namespace SportAPI.Migrations
{
    public partial class deleteUnUsefulUserInClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportClub_User_UserId",
                schema: "Sport",
                table: "SportClub");

            migrationBuilder.DropIndex(
                name: "IX_SportClub_UserId",
                schema: "Sport",
                table: "SportClub");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Sport",
                table: "SportClub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Sport",
                table: "SportClub",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SportClub_UserId",
                schema: "Sport",
                table: "SportClub",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SportClub_User_UserId",
                schema: "Sport",
                table: "SportClub",
                column: "UserId",
                principalSchema: "Sport",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
