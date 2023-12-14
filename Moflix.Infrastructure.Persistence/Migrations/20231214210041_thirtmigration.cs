using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moflix.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class thirtmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Src",
                table: "Movies");
        }
    }
}
