using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LOLApi.Migrations
{
    /// <inheritdoc />
    public partial class addednewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdaptiveId",
                table: "Champions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Champions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RangeId",
                table: "Champions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Champions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdaptiveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdaptiveName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdaptiveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    championId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsAbilities_Champions_championId",
                        column: x => x.championId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champions_AdaptiveId",
                table: "Champions",
                column: "AdaptiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_ClassId",
                table: "Champions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_RangeId",
                table: "Champions",
                column: "RangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_RegionId",
                table: "Champions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsAbilities_championId",
                table: "ChampionsAbilities",
                column: "championId");

            migrationBuilder.AddForeignKey(
                name: "FK_Champions_AdaptiveTypes_AdaptiveId",
                table: "Champions",
                column: "AdaptiveId",
                principalTable: "AdaptiveTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Champions_ChampionClasses_ClassId",
                table: "Champions",
                column: "ClassId",
                principalTable: "ChampionClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Champions_ChampionsRegion_RegionId",
                table: "Champions",
                column: "RegionId",
                principalTable: "ChampionsRegion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Champions_RangeTypes_RangeId",
                table: "Champions",
                column: "RangeId",
                principalTable: "RangeTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Champions_AdaptiveTypes_AdaptiveId",
                table: "Champions");

            migrationBuilder.DropForeignKey(
                name: "FK_Champions_ChampionClasses_ClassId",
                table: "Champions");

            migrationBuilder.DropForeignKey(
                name: "FK_Champions_ChampionsRegion_RegionId",
                table: "Champions");

            migrationBuilder.DropForeignKey(
                name: "FK_Champions_RangeTypes_RangeId",
                table: "Champions");

            migrationBuilder.DropTable(
                name: "AdaptiveTypes");

            migrationBuilder.DropTable(
                name: "ChampionClasses");

            migrationBuilder.DropTable(
                name: "ChampionsAbilities");

            migrationBuilder.DropTable(
                name: "ChampionsRegion");

            migrationBuilder.DropTable(
                name: "RangeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Champions_AdaptiveId",
                table: "Champions");

            migrationBuilder.DropIndex(
                name: "IX_Champions_ClassId",
                table: "Champions");

            migrationBuilder.DropIndex(
                name: "IX_Champions_RangeId",
                table: "Champions");

            migrationBuilder.DropIndex(
                name: "IX_Champions_RegionId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "AdaptiveId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "RangeId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Champions");
        }
    }
}
