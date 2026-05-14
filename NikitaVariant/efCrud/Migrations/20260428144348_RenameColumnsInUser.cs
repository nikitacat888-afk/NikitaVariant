using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCrud.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "users",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "users",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");
        }
    }
}
