using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameApi.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    IdealPlayerCount = table.Column<int>(type: "int", nullable: true),
                    Playtime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GamesPlayed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Players = table.Column<int>(type: "int", nullable: false),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesPlayed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesPlayed_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerScore = table.Column<int>(type: "int", nullable: false),
                    GamePlayedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_GamesPlayed_GamePlayedId",
                        column: x => x.GamePlayedId,
                        principalTable: "GamesPlayed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "Description", "Difficulty", "IdealPlayerCount", "MaxPlayers", "MinPlayers", "Name", "Playtime", "Rank" },
                values: new object[,]
                {
                    { 1, "Collect resources and build settlements", 2, 4, 4, 3, "Catan", 60, 4 },
                    { 2, "Collect train cards and build routes", 1, 4, 5, 2, "Ticket to Ride", 45, 3 },
                    { 3, "Build your city and earn coins", 1, 3, 5, 2, "Machi Koro 2", 30, 2 },
                    { 4, "Push your luck and brew potions", 2, 4, 4, 2, "Quacks of Quedlinburg", 45, 1 },
                    { 5, "Collect gems and build your empire", 1, 3, 4, 2, "Splendor", 30, 5 },
                    { 6, "Guess the word and win the round", 1, 6, 99, 3, "Word Slam", 45, 6 },
                    { 7, "Find the spies and save the world", 1, 7, 10, 5, "The Resistance", 30, 7 },
                    { 8, "Place tiles and stay on the board to be the last one standing", 1, 5, 8, 2, "Tsuro", 15, 8 },
                    { 9, "Work together to collect treasures and escape the island", 1, 4, 4, 2, "Forbidden Island", 30, 9 },
                    { 10, "Pirate your way to the most loot", 1, 6, 8, 2, "Loot", 30, 10 },
                    { 11, "Roll dice and fill in your sheet to earn the highest score", 1, 3, 4, 1, "That's So Clever", 30, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlayed_BoardGameId",
                table: "GamesPlayed",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GamePlayedId",
                table: "Scores",
                column: "GamePlayedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "GamesPlayed");

            migrationBuilder.DropTable(
                name: "BoardGames");
        }
    }
}
