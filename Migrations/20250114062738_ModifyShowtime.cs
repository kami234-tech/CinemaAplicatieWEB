using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAplicatieWEB.Migrations
{
    /// <inheritdoc />
    public partial class ModifyShowtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add new column 'Time' to the 'Showtimes' table
            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Showtimes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop 'Time' column if rolling back the migration
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Showtimes");
        }
    }
}

