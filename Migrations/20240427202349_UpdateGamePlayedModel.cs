using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGamePlayedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comments",
                table: "GamesPlayed",
                newName: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "GamesPlayed",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "GamesPlayed");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "GamesPlayed",
                newName: "comments");
        }
    }
}
