using Microsoft.EntityFrameworkCore.Migrations;

namespace SportAPI.Migrations
{
    public partial class League : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LeagueId",
                schema: "Sport",
                table: "SportClub",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "League",
                schema: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHigh = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "'1'"),
                    CountForChampionsLeague = table.Column<int>(type: "int", nullable: false),
                    CountForEuropeLeague = table.Column<int>(type: "int", nullable: false),
                    CountForConferenceLeague = table.Column<int>(type: "int", nullable: false),
                    CountForDownLeague = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportClub_LeagueId",
                schema: "Sport",
                table: "SportClub",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportClub_League_LeagueId",
                schema: "Sport",
                table: "SportClub",
                column: "LeagueId",
                principalSchema: "Sport",
                principalTable: "League",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportClub_League_LeagueId",
                schema: "Sport",
                table: "SportClub");

            migrationBuilder.DropTable(
                name: "League",
                schema: "Sport");

            migrationBuilder.DropIndex(
                name: "IX_SportClub_LeagueId",
                schema: "Sport",
                table: "SportClub");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                schema: "Sport",
                table: "SportClub");
        }
    }
}
