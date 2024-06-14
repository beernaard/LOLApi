using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LOLApi.Migrations
{
    /// <inheritdoc />
    public partial class initalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampionsPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    championTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    championImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    championDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionsPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "ChampionsPositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champions_PositionId",
                table: "Champions",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "ChampionsPositions");
        }
    }
}
