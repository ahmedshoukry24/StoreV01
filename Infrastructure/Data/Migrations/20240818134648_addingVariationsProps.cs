using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingVariationsProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPU",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Variations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraphicsDescription",
                table: "Variations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Variations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAM",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialFeatures",
                table: "Variations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Style",
                table: "Variations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "Variations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPU",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "GraphicsDescription",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "RAM",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "SpecialFeatures",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Variations");
        }
    }
}
