using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRestApi.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Movies",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Directors",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Categories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Actors",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Movies",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Directors",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Categories",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Actors",
                newName: "İsDeleted");
        }
    }
}
