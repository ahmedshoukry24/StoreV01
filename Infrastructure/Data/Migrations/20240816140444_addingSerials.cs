using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingSerials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Stores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Products",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Categories",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Branches",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Branches");
        }
    }
}
