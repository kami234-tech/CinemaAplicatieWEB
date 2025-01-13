using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAplicatieWEB.Migrations
{
    /// <inheritdoc />
    public partial class AddGenresToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Movie",
                newName: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genres",
                table: "Movie",
                newName: "Genre");
        }
    }
}
